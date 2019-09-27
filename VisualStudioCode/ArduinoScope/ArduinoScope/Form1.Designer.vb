<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrcheckcomportcount = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.zg1 = New ZedGraph.ZedGraphControl()
        Me.tmrGraphUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.btnResetTrigger = New System.Windows.Forms.Button()
        Me.btnResetTraceSelection = New System.Windows.Forms.Button()
        Me.chkA0 = New System.Windows.Forms.CheckBox()
        Me.chkA1 = New System.Windows.Forms.CheckBox()
        Me.chkA2 = New System.Windows.Forms.CheckBox()
        Me.chkA3 = New System.Windows.Forms.CheckBox()
        Me.chkA4 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTriggerSamples = New System.Windows.Forms.TextBox()
        Me.chkFalling0 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkFalling1 = New System.Windows.Forms.CheckBox()
        Me.chkFalling2 = New System.Windows.Forms.CheckBox()
        Me.chkFalling3 = New System.Windows.Forms.CheckBox()
        Me.chkFalling4 = New System.Windows.Forms.CheckBox()
        Me.chkNoTrigger = New System.Windows.Forms.CheckBox()
        Me.chkStartTriggerTimer = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTimeSinceTrigger = New System.Windows.Forms.Label()
        Me.btnResetTimer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tmrcheckcomportcount
        '
        Me.tmrcheckcomportcount.Interval = 10000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 394)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'zg1
        '
        Me.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left
        Me.zg1.Location = New System.Drawing.Point(12, 12)
        Me.zg1.Name = "zg1"
        Me.zg1.PanModifierKeys = CType((System.Windows.Forms.Keys.Shift Or System.Windows.Forms.Keys.None), System.Windows.Forms.Keys)
        Me.zg1.ScrollGrace = 0R
        Me.zg1.ScrollMaxX = 0R
        Me.zg1.ScrollMaxY = 0R
        Me.zg1.ScrollMaxY2 = 0R
        Me.zg1.ScrollMinX = 0R
        Me.zg1.ScrollMinY = 0R
        Me.zg1.ScrollMinY2 = 0R
        Me.zg1.Size = New System.Drawing.Size(1664, 361)
        Me.zg1.TabIndex = 314
        '
        'tmrGraphUpdate
        '
        Me.tmrGraphUpdate.Interval = 250
        '
        'btnResetTrigger
        '
        Me.btnResetTrigger.Location = New System.Drawing.Point(12, 425)
        Me.btnResetTrigger.Name = "btnResetTrigger"
        Me.btnResetTrigger.Size = New System.Drawing.Size(162, 35)
        Me.btnResetTrigger.TabIndex = 315
        Me.btnResetTrigger.Text = "Reset trigger"
        Me.btnResetTrigger.UseVisualStyleBackColor = True
        '
        'btnResetTraceSelection
        '
        Me.btnResetTraceSelection.Location = New System.Drawing.Point(12, 466)
        Me.btnResetTraceSelection.Name = "btnResetTraceSelection"
        Me.btnResetTraceSelection.Size = New System.Drawing.Size(162, 35)
        Me.btnResetTraceSelection.TabIndex = 316
        Me.btnResetTraceSelection.Text = "Reset trace selection"
        Me.btnResetTraceSelection.UseVisualStyleBackColor = True
        '
        'chkA0
        '
        Me.chkA0.AutoSize = True
        Me.chkA0.Location = New System.Drawing.Point(222, 425)
        Me.chkA0.Name = "chkA0"
        Me.chkA0.Size = New System.Drawing.Size(129, 17)
        Me.chkA0.TabIndex = 317
        Me.chkA0.Text = "A0 (3v3 on Capacitor)"
        Me.chkA0.UseVisualStyleBackColor = True
        '
        'chkA1
        '
        Me.chkA1.AutoSize = True
        Me.chkA1.Location = New System.Drawing.Point(222, 448)
        Me.chkA1.Name = "chkA1"
        Me.chkA1.Size = New System.Drawing.Size(124, 17)
        Me.chkA1.TabIndex = 318
        Me.chkA1.Text = "A1 (Potted down 5V)"
        Me.chkA1.UseVisualStyleBackColor = True
        '
        'chkA2
        '
        Me.chkA2.AutoSize = True
        Me.chkA2.Location = New System.Drawing.Point(222, 471)
        Me.chkA2.Name = "chkA2"
        Me.chkA2.Size = New System.Drawing.Size(77, 17)
        Me.chkA2.TabIndex = 319
        Me.chkA2.Text = "A2 (5V rail)"
        Me.chkA2.UseVisualStyleBackColor = True
        '
        'chkA3
        '
        Me.chkA3.AutoSize = True
        Me.chkA3.Location = New System.Drawing.Point(222, 494)
        Me.chkA3.Name = "chkA3"
        Me.chkA3.Size = New System.Drawing.Size(92, 17)
        Me.chkA3.TabIndex = 320
        Me.chkA3.Text = "A3 (Pot wiper)"
        Me.chkA3.UseVisualStyleBackColor = True
        '
        'chkA4
        '
        Me.chkA4.AutoSize = True
        Me.chkA4.Location = New System.Drawing.Point(222, 517)
        Me.chkA4.Name = "chkA4"
        Me.chkA4.Size = New System.Drawing.Size(183, 17)
        Me.chkA4.TabIndex = 321
        Me.chkA4.Text = "A4 (Debug out square wave 3v3)"
        Me.chkA4.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 394)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 322
        Me.Label2.Text = "Trace Enabled"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(425, 424)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton1.TabIndex = 323
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(425, 448)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton2.TabIndex = 324
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(425, 471)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton3.TabIndex = 325
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(425, 494)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton4.TabIndex = 326
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(425, 517)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton5.TabIndex = 327
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(422, 394)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 328
        Me.Label3.Text = "Trigger on"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(492, 394)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 329
        Me.Label4.Text = "Trigger level (V)"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(495, 417)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(39, 20)
        Me.TextBox1.TabIndex = 330
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(495, 440)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(39, 20)
        Me.TextBox2.TabIndex = 331
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(495, 464)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(39, 20)
        Me.TextBox3.TabIndex = 332
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(495, 487)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(39, 20)
        Me.TextBox4.TabIndex = 333
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(495, 510)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(39, 20)
        Me.TextBox5.TabIndex = 334
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 549)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 13)
        Me.Label5.TabIndex = 335
        Me.Label5.Text = "Number of samples after trigger"
        '
        'txtTriggerSamples
        '
        Me.txtTriggerSamples.Location = New System.Drawing.Point(222, 565)
        Me.txtTriggerSamples.Name = "txtTriggerSamples"
        Me.txtTriggerSamples.Size = New System.Drawing.Size(39, 20)
        Me.txtTriggerSamples.TabIndex = 336
        Me.txtTriggerSamples.Text = "350"
        '
        'chkFalling0
        '
        Me.chkFalling0.AutoSize = True
        Me.chkFalling0.Location = New System.Drawing.Point(605, 425)
        Me.chkFalling0.Name = "chkFalling0"
        Me.chkFalling0.Size = New System.Drawing.Size(15, 14)
        Me.chkFalling0.TabIndex = 337
        Me.chkFalling0.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(602, 394)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 13)
        Me.Label6.TabIndex = 338
        Me.Label6.Text = "Select for < (otherwise >)"
        '
        'chkFalling1
        '
        Me.chkFalling1.AutoSize = True
        Me.chkFalling1.Location = New System.Drawing.Point(605, 449)
        Me.chkFalling1.Name = "chkFalling1"
        Me.chkFalling1.Size = New System.Drawing.Size(15, 14)
        Me.chkFalling1.TabIndex = 339
        Me.chkFalling1.UseVisualStyleBackColor = True
        '
        'chkFalling2
        '
        Me.chkFalling2.AutoSize = True
        Me.chkFalling2.Location = New System.Drawing.Point(605, 474)
        Me.chkFalling2.Name = "chkFalling2"
        Me.chkFalling2.Size = New System.Drawing.Size(15, 14)
        Me.chkFalling2.TabIndex = 340
        Me.chkFalling2.UseVisualStyleBackColor = True
        '
        'chkFalling3
        '
        Me.chkFalling3.AutoSize = True
        Me.chkFalling3.Location = New System.Drawing.Point(605, 497)
        Me.chkFalling3.Name = "chkFalling3"
        Me.chkFalling3.Size = New System.Drawing.Size(15, 14)
        Me.chkFalling3.TabIndex = 341
        Me.chkFalling3.UseVisualStyleBackColor = True
        '
        'chkFalling4
        '
        Me.chkFalling4.AutoSize = True
        Me.chkFalling4.Location = New System.Drawing.Point(605, 518)
        Me.chkFalling4.Name = "chkFalling4"
        Me.chkFalling4.Size = New System.Drawing.Size(15, 14)
        Me.chkFalling4.TabIndex = 342
        Me.chkFalling4.UseVisualStyleBackColor = True
        '
        'chkNoTrigger
        '
        Me.chkNoTrigger.AutoSize = True
        Me.chkNoTrigger.Location = New System.Drawing.Point(15, 537)
        Me.chkNoTrigger.Name = "chkNoTrigger"
        Me.chkNoTrigger.Size = New System.Drawing.Size(187, 17)
        Me.chkNoTrigger.TabIndex = 343
        Me.chkNoTrigger.Text = "Select for NO trigger (free running)"
        Me.chkNoTrigger.UseVisualStyleBackColor = True
        '
        'chkStartTriggerTimer
        '
        Me.chkStartTriggerTimer.AutoSize = True
        Me.chkStartTriggerTimer.Location = New System.Drawing.Point(15, 568)
        Me.chkStartTriggerTimer.Name = "chkStartTriggerTimer"
        Me.chkStartTriggerTimer.Size = New System.Drawing.Size(120, 17)
        Me.chkStartTriggerTimer.TabIndex = 344
        Me.chkStartTriggerTimer.Text = "Start timer on trigger"
        Me.chkStartTriggerTimer.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 588)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 345
        Me.Label7.Text = "Time since trigger"
        '
        'lblTimeSinceTrigger
        '
        Me.lblTimeSinceTrigger.AutoSize = True
        Me.lblTimeSinceTrigger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeSinceTrigger.Location = New System.Drawing.Point(15, 611)
        Me.lblTimeSinceTrigger.Name = "lblTimeSinceTrigger"
        Me.lblTimeSinceTrigger.Size = New System.Drawing.Size(15, 15)
        Me.lblTimeSinceTrigger.TabIndex = 346
        Me.lblTimeSinceTrigger.Text = "0"
        '
        'btnResetTimer
        '
        Me.btnResetTimer.Location = New System.Drawing.Point(140, 588)
        Me.btnResetTimer.Name = "btnResetTimer"
        Me.btnResetTimer.Size = New System.Drawing.Size(62, 35)
        Me.btnResetTimer.TabIndex = 347
        Me.btnResetTimer.Text = "Reset timer"
        Me.btnResetTimer.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1679, 646)
        Me.Controls.Add(Me.btnResetTimer)
        Me.Controls.Add(Me.lblTimeSinceTrigger)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkStartTriggerTimer)
        Me.Controls.Add(Me.chkNoTrigger)
        Me.Controls.Add(Me.chkFalling4)
        Me.Controls.Add(Me.chkFalling3)
        Me.Controls.Add(Me.chkFalling2)
        Me.Controls.Add(Me.chkFalling1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkFalling0)
        Me.Controls.Add(Me.txtTriggerSamples)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkA4)
        Me.Controls.Add(Me.chkA3)
        Me.Controls.Add(Me.chkA2)
        Me.Controls.Add(Me.chkA1)
        Me.Controls.Add(Me.chkA0)
        Me.Controls.Add(Me.btnResetTraceSelection)
        Me.Controls.Add(Me.btnResetTrigger)
        Me.Controls.Add(Me.zg1)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Oscilloscope (Arduino)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrcheckcomportcount As Timer
    Friend WithEvents Label1 As Label
    Private WithEvents zg1 As ZedGraph.ZedGraphControl
    Friend WithEvents tmrGraphUpdate As Timer
    Friend WithEvents btnResetTrigger As Button
    Friend WithEvents btnResetTraceSelection As Button
    Friend WithEvents chkA0 As CheckBox
    Friend WithEvents chkA1 As CheckBox
    Friend WithEvents chkA2 As CheckBox
    Friend WithEvents chkA3 As CheckBox
    Friend WithEvents chkA4 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTriggerSamples As TextBox
    Friend WithEvents chkFalling0 As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkFalling1 As CheckBox
    Friend WithEvents chkFalling2 As CheckBox
    Friend WithEvents chkFalling3 As CheckBox
    Friend WithEvents chkFalling4 As CheckBox
    Friend WithEvents chkNoTrigger As CheckBox
    Friend WithEvents chkStartTriggerTimer As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTimeSinceTrigger As Label
    Friend WithEvents btnResetTimer As Button
End Class
