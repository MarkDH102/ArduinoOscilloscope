byte                        _bytADCnum;
byte                        _bytADCdata[6];
volatile  bool              _blnSync = false;
int                         _intCommsInCount = 0;
byte                        _bytCommsBuff[10];

void setup ()
{
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);

  _bytADCnum = 0;
  _blnSync = false;
  _intCommsInCount = 0;
  
  // disable digital buffer on A0, A1, A2, A3, A4, A5
  bitSet (DIDR0, ADC0D);
  bitSet (DIDR0, ADC1D);
  bitSet (DIDR0, ADC2D);
  bitSet (DIDR0, ADC3D);
  bitSet (DIDR0, ADC4D);
  bitSet (DIDR0, ADC5D);
  
  // 1MHz is the fastest we can stuff out info due to bandwidth issues
  // 60000 samples comes out in 7.229332 seconds @ 500kHz
  // 60000 samples comes out in 6.876268 seconds @ 1MHz
  // 60000 samples comes out in 6.876124 seconds @ 2MHz  
  Serial.begin (1000000);
  
  // Generate PWM (test signal)
  //pinMode(3, OUTPUT);
  //pinMode(11, OUTPUT);
  //TCCR2A = _BV(COM2A0) | _BV(COM2B1) | _BV(WGM20);
  //TCCR2B = _BV(WGM22) | _BV(CS22);
  //OCR2A = 180;
  //OCR2B = 50;

  // turn ADC on and set to free run
  ADCSRA =  bit (ADEN) | bit (ADATE);
  // Prescaler of 16
  ADCSRA |= bit (ADPS2);
  // Prescaler of 64
  ADCSRA |= bit(ADPS1);
  // all bits set is 128, s2 and s1 set are 64, s2 and s0 is 32
  
  // AVcc and select input port and left justify into high byte for an 8 bit value
  ADMUX  =  bit(ADLAR) | bit (REFS0) | (0 & 0x07);
  // Start conversions and enable the interrupt
  ADCSRA |= bit (ADSC) | bit (ADIE);
}

// ADC complete ISR
ISR (ADC_vect)
{
  _bytADCdata[_bytADCnum] = ADCH;
  if (_bytADCnum++ == 6)
  {
    _bytADCnum = 0;
    if (_blnSync == true)
      Serial.write(&_bytADCdata[1], 5);
  }
  ADMUX = _bytADCnum | bit(REFS0) | bit(ADLAR);
}


void loop ()
{
  // All the main loop does is check for serial comms to resync the ADC outgoing serial message with the PC end
  if (Serial.available()) 
  {
    byte a = Serial.read();
    if (a == 13)
    {
      _intCommsInCount = 0;
      if (_bytCommsBuff[0] == 'S' && _bytCommsBuff[1] == 'Y')
      {
        Serial.flush();
        delay(100);
        _blnSync = true;
        //digitalWrite(LED_BUILTIN, HIGH);
      }
      if (_bytCommsBuff[0] == 'N' && _bytCommsBuff[1]  == 'O')
      {
        _blnSync = false;
        Serial.flush();
        //digitalWrite(LED_BUILTIN, LOW);
      }
    }
    else
    {
      _bytCommsBuff[_intCommsInCount++] = a;
      if (_intCommsInCount > 3)
      {
        _intCommsInCount = 0;
      }
    }
  }
}
