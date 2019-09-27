Imports System.Threading
Imports ZedGraph



Public Class Form1

    Dim WithEvents serialPort As New IO.Ports.SerialPort

    ' Used to hold the comms data received by the DataReceived event
    Private mstrSerialData As String = ""
    Private mblnSerialDataValid As Boolean
    Private mbytBuffer(4096) As Byte
    Private mblnCOMportFound As Boolean = False
    ' A flag that is set to true when we have received some data on the serial port
    ' Set TRUE in the Delegate function
    Private mblnCommsReceived As Boolean = False
    ' Flag to tell the DataReceive delegate function that a serial port close is pending
    Private mblnClosePending As Boolean = False

    Private mintIn As Integer
    Private mintLook As Integer
    Private mintOut As Integer
    Private mbytWorkingBuffer(8192) As Byte
    Private mintBytesIn As Integer
    Private mintBytesOut As Integer
    Private mCommsThread As Thread
    Private mbytData(10) As Byte
    Private mblnThreadEnd As Boolean
    Private _blnSYsent = False
    Private mintTossCount As Integer
    Private mintTriggeredCount As Integer
    Private mintTriggerChannel As Integer
    Private mbytTriggerLevel As Byte
    Private mintSamplesAfterTrigger As Integer
    Private mblnFalling As Boolean
    Private mdblStart As Date
    Private mblnTimerStarted As Boolean
    Private _bc As Byte



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGraphAxes()

        mintTriggeredCount = 0
        mblnTimerStarted = False
        'mintTriggerChannel = 1
        'mbytTriggerLevel = 3.3 / 5 * 255
        'TextBox2.Text = 3.3
        'mblnFalling = True
        'chkFalling1.Checked = True
        'RadioButton2.Checked = True
        'mintSamplesAfterTrigger = 350

        mintTriggerChannel = 4
        mbytTriggerLevel = 1.0 / 5 * 255
        TextBox5.Text = 1.0
        RadioButton5.Checked = True
        mintSamplesAfterTrigger = MAX_POINTS - 50

        txtTriggerSamples.Text = CStr(mintSamplesAfterTrigger)

        chkA0.Checked = True
        chkA1.Checked = True
        chkA2.Checked = True
        chkA3.Checked = True
        chkA4.Checked = True
        chkA0.ForeColor = Color.Blue
        chkA1.ForeColor = Color.Red
        chkA2.ForeColor = Color.Green
        chkA3.ForeColor = Color.Pink
        chkA4.ForeColor = Color.Brown

        mintTossCount = 0
        mintIn = 0
        mintOut = 0
        mintLook = 0
        mintBytesIn = 0
        mintBytesOut = 0
        mblnThreadEnd = False
        mblnCOMportFound = False
        _blnSYsent = False
        _bc = 0

        mblnTriggered = False

        ' Set the timer going that regularly checks for additional com ports being added
        tmrcheckcomportcount.Enabled = True
        tmrcheckcomportcount.Interval = 2000

        tmrGraphUpdate.Enabled = True
        tmrGraphUpdate.Interval = 25

        mCommsThread = New Thread(AddressOf ThreadTask)
        mCommsThread.IsBackground = True
        mCommsThread.Start()

    End Sub


    Private Sub DataReceived(
       ByVal sender As Object,
       ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
       Handles serialPort.DataReceived

        Dim intC As Integer
        Dim intI As Integer

        ' Set flag to say we have at least received some comms
        mblnCommsReceived = True

        ' If the serial port is about to be closed then don't try and receive any more characters
        ' I think but can't prove 100% that NOT doing this locks the serial.close up
        If mblnClosePending = True Then Exit Sub

        mblnCOMportFound = True

        Try
            ' Read the bytes regardless
            intC = serialPort.BytesToRead
            serialPort.Read(mbytBuffer, 0, intC)

            If _blnSYsent = False Then Exit Sub

            ' Copy to the circular buffer
            For intI = 0 To intC - 1
                mbytWorkingBuffer(mintIn) = mbytBuffer(intI)
                mintIn += 1
                mintBytesIn += 1
                If mintIn >= mbytWorkingBuffer.Length Then
                    mintIn = 0
                End If
                If mintIn = mintOut And mintBytesIn <> mintBytesOut Then
                    'Don't get stomping over existing data, just toss away
                    Debug.Print("Packets lost: " + Str(mintTossCount))
                    mintTossCount += 1
                    Exit For
                End If
            Next
        Catch ex As Exception
            intC = 1
        End Try

    End Sub


    Private Sub ThreadTask()

        Dim c As Byte

        Try
            Do
                If mblnThreadEnd = True Then Exit Do

                If mintIn <> mintOut Then
                    c = mbytWorkingBuffer(mintOut)
                    mintOut += 1
                    mintBytesOut += 1
                    If mintOut >= mbytWorkingBuffer.Length Then
                        mintOut = 0
                    End If

                    mbytData(_bc) = c
                    _bc += 1
                    If _bc = 5 Then
                        _bc = 0
                        PutDataIntoGraph(mbytData)
                    End If

                    'End If
                End If
            Loop
        Catch ex As Exception
            c = 0
        End Try

    End Sub

    Private Sub resyncArduino()

        Dim bytStart(3) As Byte
        Dim bytStop(3) As Byte

        _blnSYsent = False

        ' Send NO to stop the Arduino transmitting
        bytStop(0) = 78
        bytStop(1) = 79
        bytStop(2) = 13
        serialPort.Write(bytStop, 0, 3)

        Dim dblT As Double = Microsoft.VisualBasic.DateAndTime.Timer + 0.2
        Do While Microsoft.VisualBasic.DateAndTime.Timer < dblT
            Application.DoEvents()
        Loop

        Debug.Print("New")
        Debug.Print(serialPort.BytesToRead)

        serialPort.DiscardInBuffer()
        If serialPort.BytesToRead > 0 Then
            serialPort.ReadExisting()
        End If


        _blnSYsent = True
        _bc = 0

        ' Send SY to start the Arduino transmitting (after 1s)
        bytStart(0) = 83
        bytStart(1) = 89
        bytStart(2) = 13

        Debug.Print(serialPort.BytesToRead)

        serialPort.Write(bytStart, 0, 3)

        mintTossCount = 0
        mintIn = 0
        mintOut = 0
        mintLook = 0
        mintBytesIn = 0
        mintBytesOut = 0

    End Sub

    ' This timer is running at 2s intervals
    ' Check through all COM PORTS in the system
    ' If the GPS device is attached to one, then the DataReceived event will fire
    ' and the mblnCOMportFound flag will be set to true so this timer no longer executes
    Private Sub tmrCheckCOMportCount_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrcheckcomportcount.Tick

        Dim strPortName As String
        Static sintPort As Integer = 0

        strPortName = ""
        If mblnCOMportFound = False Then

            sintPort += 1
            If sintPort > My.Computer.Ports.SerialPortNames.Count Then sintPort = 1

            Try
                strPortName = My.Computer.Ports.SerialPortNames(sintPort - 1)
                If Microsoft.VisualBasic.Right(strPortName, 1) < "0" Or Microsoft.VisualBasic.Right(strPortName, 1) > "9" Then
                    strPortName = Microsoft.VisualBasic.Left(strPortName, Len(strPortName) - 1)
                End If
            Catch ex As Exception
                ' If the PC has NO com ports then ignore error
                strPortName = ""
            End Try

            If Len(strPortName) > 0 Then
                ' Open the serial port
                Try
                    With serialPort
                        If .IsOpen = True Then .Close()
                        .PortName = strPortName
                        .BaudRate = 1000000
                        .Parity = IO.Ports.Parity.None
                        .DataBits = 8
                        .StopBits = IO.Ports.StopBits.One
                        .ReadTimeout = 100
                        .WriteTimeout = 150
                        .ReceivedBytesThreshold = 1
                    End With

                    serialPort.Open()

                    resyncArduino()

                    mblnClosePending = False

                Catch ex As Exception
                    strPortName = ""
                    ' Do nothing if port does not exist
                End Try
            End If

        Else
            Label1.Text = "Packets lost: " + Str(mintTossCount)
        End If

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' Make sure that the "Delegate" function does not take any comms in while we are trying to close the port
        mblnClosePending = True
        'MDH REMOVE
        mblnThreadEnd = True
        ' Wait for 1s
        Dim dblT As Double = Microsoft.VisualBasic.DateAndTime.Timer + 1.0
        Do While Microsoft.VisualBasic.DateAndTime.Timer < dblT
            Application.DoEvents()
        Loop

        Try
            If serialPort.IsOpen Then
                ' Wait for .5s
                dblT = Microsoft.VisualBasic.DateAndTime.Timer + 0.5
                Do While Microsoft.VisualBasic.DateAndTime.Timer < dblT
                    Application.DoEvents()
                Loop
                serialPort.Close()
            End If
        Catch ex As Exception
        End Try

        ' Wait for 1s
        dblT = Microsoft.VisualBasic.DateAndTime.Timer + 1.0
        Do While Microsoft.VisualBasic.DateAndTime.Timer < dblT
            Application.DoEvents()
        Loop

        mblnClosePending = False

        If tmrcheckcomportcount.Enabled = True Then tmrcheckcomportcount.Enabled = False

    End Sub

    Private Const MAX_POINTS = 400
    Private Const MAX_CURVES = 5
    Private Const SCALE_FONT_SIZE = 10

    Dim myPane As GraphPane
    Dim mycurve(MAX_CURVES) As LineItem
    Dim list(MAX_CURVES) As RollingPointPairList
    Dim mintPoint As Integer = 0
    Dim mblnCurveUsed(MAX_CURVES)
    Dim mblnTriggered As Boolean

    ' ============================================================= ZEDGRAPH ==========================================================


    Private Sub SetupGraphAxes()

        Dim intC As Integer
        Dim col1 As Color() = {Color.Blue, Color.Red, Color.Green, Color.HotPink, Color.Brown}
        myPane = zg1.GraphPane

        mintPoint = 0

        zg1.IsEnableHPan = False
        zg1.IsEnableHZoom = False
        zg1.IsEnableVPan = False
        zg1.IsEnableVZoom = False
        zg1.IsEnableWheelZoom = False

        For intC = 0 To MAX_CURVES - 1
            list(intC) = New RollingPointPairList(MAX_POINTS * 10)
            mycurve(intC) = myPane.AddCurve("", list(intC), col1(intC), SymbolType.None)
            mblnCurveUsed(intC) = True
        Next

        ' Set the titles And axis labels
        myPane.Title.Text = ""
        myPane.XAxis.Title.Text = "Time (s)"

        ' Show the x axis grid
        myPane.XAxis.MajorGrid.IsVisible = True

        ' Make the Y axis scale red
        myPane.YAxis.Title.Text = ""
        myPane.YAxis.Scale.FontSpec.FontColor = col1(0)
        myPane.YAxis.Scale.FontSpec.Size = SCALE_FONT_SIZE
        myPane.YAxis.Title.FontSpec.FontColor = col1(0)
        ' turn off the opposite tics so the Y tics don't show up on the Y2 axis
        myPane.YAxis.MajorTic.IsOpposite = False
        myPane.YAxis.MinorTic.IsOpposite = False
        ' Don't display the Y zero line
        myPane.YAxis.MajorGrid.IsZeroLine = False
        ' Align the Y axis labels so they are flush to the axis
        myPane.YAxis.Scale.Align = AlignP.Inside
        myPane.YAxis.MinorTic.Size = 0.0F

        myPane.XAxis.Scale.Min = 0
        myPane.XAxis.Scale.Max = MAX_POINTS
        myPane.XAxis.Color = Color.Black
        myPane.XAxis.MajorGrid.Color = Color.Black
        myPane.XAxis.MinorGrid.Color = Color.Black
        myPane.XAxis.Scale.MajorStep = 10
        myPane.XAxis.Scale.Format = "f0"

        ' Fill the axis background with a gradient
        myPane.Chart.Fill = New Fill(Color.White, Color.LightGray, 45.0F)

        ' Don't show scroll bars
        zg1.IsShowHScrollBar = False
        zg1.IsShowVScrollBar = False
        zg1.IsAutoScrollRange = False
        zg1.IsScrollY2 = False

        ' Setup the scale (volts)
        myPane.YAxis.Scale.Min = -0.1
        myPane.YAxis.Scale.Max = 5.1
        myPane.YAxis.Scale.MajorStep = 0.25

        ' Tell ZedGraph to calculate the axis ranges
        ' Note that you MUST call this after enabling IsAutoScrollRange, since AxisChange() sets
        ' up the proper scrolling parameters
        zg1.AxisChange()
        ' Make sure the Graph gets redrawn
        zg1.Invalidate()
    End Sub


    Sub PutDataIntoGraph(bytCnl() As Byte)

        Dim intC As Integer

        If chkNoTrigger.Checked = False Then
            If mblnTriggered = True And mintTriggeredCount = mintSamplesAfterTrigger Then Exit Sub

            If mblnFalling = True Then
                If bytCnl(mintTriggerChannel) < mbytTriggerLevel Then
                    mblnTriggered = True
                    If mblnTimerStarted = False And chkStartTriggerTimer.Checked = True Then
                        mdblStart = Now
                        mblnTimerStarted = True
                    End If
                End If
            Else
                If bytCnl(mintTriggerChannel) > mbytTriggerLevel Then
                    mblnTriggered = True
                    If mblnTimerStarted = False And chkStartTriggerTimer.Checked = True Then
                        mdblStart = Now
                        mblnTimerStarted = True
                    End If
                End If
            End If
        End If

        If mblnTriggered = True Then
            mintTriggeredCount += 1
        End If

        For intC = 0 To MAX_CURVES - 1
            If mblnCurveUsed(intC) = True Then
                ' Calculate volts based on an 8 bit converter running off a 5V ref.
                list(intC).Add(mintPoint, (5 * bytCnl(intC)) / 255)
            End If
        Next
        mintPoint += 1
        If mintPoint >= MAX_POINTS Then
            myPane.XAxis.Scale.Min += 1
            myPane.XAxis.Scale.Max += 1
        End If

    End Sub

    Private Sub tmrGraphUpdate_Tick(sender As Object, e As EventArgs) Handles tmrGraphUpdate.Tick
        If mblnCOMportFound = True Then
            zg1.Invalidate()
            If chkStartTriggerTimer.Checked = True And mblnTriggered = True Then
                lblTimeSinceTrigger.Text = (Now - mdblStart).TotalMilliseconds
            End If
        End If
    End Sub

    Private Sub btnResetTrigger_Click(sender As Object, e As EventArgs) Handles btnResetTrigger.Click

        resyncArduino()
        mintTriggeredCount = 0
        mblnTriggered = False

    End Sub

    Private Sub btnResetTraceSelection_Click(sender As Object, e As EventArgs) Handles btnResetTraceSelection.Click

        mblnCurveUsed(0) = chkA0.Checked
        mblnCurveUsed(1) = chkA1.Checked
        mblnCurveUsed(2) = chkA2.Checked
        mblnCurveUsed(3) = chkA3.Checked
        mblnCurveUsed(4) = chkA4.Checked

        If RadioButton1.Checked = True Then
            mintTriggerChannel = 0
            mbytTriggerLevel = CDbl(TextBox1.Text) / 5 * 255
            mblnFalling = chkFalling0.Checked
        End If
        If RadioButton2.Checked = True Then
            mintTriggerChannel = 1
            mbytTriggerLevel = CDbl(TextBox2.Text) / 5 * 255
            mblnFalling = chkFalling1.Checked
        End If
        If RadioButton3.Checked = True Then
            mintTriggerChannel = 2
            mbytTriggerLevel = CDbl(TextBox3.Text) / 5 * 255
            mblnFalling = chkFalling2.Checked
        End If
        If RadioButton4.Checked = True Then
            mintTriggerChannel = 3
            mbytTriggerLevel = CDbl(TextBox4.Text) / 5 * 255
            mblnFalling = chkFalling3.Checked
        End If
        If RadioButton5.Checked = True Then
            mintTriggerChannel = 4
            mbytTriggerLevel = CDbl(TextBox5.Text) / 5 * 255
            mblnFalling = chkFalling4.Checked
        End If

        mintSamplesAfterTrigger = CInt(txtTriggerSamples.Text)

        resyncArduino()

        mintTriggeredCount = 0
        mblnTriggered = False
    End Sub

    Private Sub chkNoTrigger_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoTrigger.CheckedChanged

        If chkNoTrigger.Checked = True Then
            mblnTriggered = False
        End If

    End Sub

    Private Sub btnResetTimer_Click(sender As Object, e As EventArgs) Handles btnResetTimer.Click
        lblTimeSinceTrigger.Text = "0"
        mdblStart = Now
        mblnTimerStarted = False
    End Sub

End Class
