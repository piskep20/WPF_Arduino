int LED_PIN1 = 0;
int LED_PIN2 = 0;
int LED_PIN3 = 0;
int LED_PIN4 = 0;
int LED_PIN5 = 0;
int LED_PIN6 = 0;
int LED_PIN7 = 0;
int LED_PIN8 = 0;
int LED_PIN9 = 0;
int LED_PIN10 = 0;
int LED_PIN11 = 0;
int LED_PIN12 = 0;
int LED_PIN13 = 0;
int LED_PIN14 = 0;
String inputString;
String Action;
String LED_Command;
void setup() {
  Serial.begin(9600);
  Serial.setTimeout(10);
  pinMode(LED_PIN1, OUTPUT);
  pinMode(LED_PIN2, OUTPUT);
  pinMode(LED_PIN3, OUTPUT);
  pinMode(LED_PIN4, OUTPUT);
  pinMode(LED_PIN5, OUTPUT);
  pinMode(LED_PIN6, OUTPUT);
  pinMode(LED_PIN7, OUTPUT);
  pinMode(LED_PIN8, OUTPUT);
  pinMode(LED_PIN9, OUTPUT);
  pinMode(LED_PIN10, OUTPUT);
  pinMode(LED_PIN11, OUTPUT);
  pinMode(LED_PIN12, OUTPUT);
  pinMode(LED_PIN13, OUTPUT);
  pinMode(LED_PIN14, OUTPUT);
}
void loop() {
  ukljuciDiode();
}
void ukljuciDiode(){
  while(Serial.available()){
    char c = Serial.read();
    if(c=='$'){
      inputString = Serial.readString();
      Action = inputString.substring(0,5);
    }
    if(Action=="DIODA"){
    LED_Command = inputString.substring(5, 8);
      if(LED_Command=="1ON"){
        turnLedOn(LED_PIN1);
      } else if (LED_Command=="2ON"){
        turnLedOn(LED_PIN2);
      }else if (LED_Command=="3ON"){
         turnLedOn(LED_PIN3);
      }else if (LED_Command=="4ON"){
        turnLedOn(LED_PIN4);
      }else if (LED_Command=="5ON"){
        turnLedOn(LED_PIN5);
      }else if (LED_Command=="6ON"){
        turnLedOn(LED_PIN6);
      }else if (LED_Command=="7ON"){
        turnLedOn(LED_PIN7);
      }else if (LED_Command=="8ON"){
        turnLedOn(LED_PIN8);
      }else if (LED_Command=="9ON"){
        turnLedOn(LED_PIN9);
      }else if (LED_Command=="10N"){
        turnLedOn(LED_PIN10);
      }else if (LED_Command=="11N"){
        turnLedOn(LED_PIN11);
      }else if (LED_Command=="12N"){
        turnLedOn(LED_PIN12);
      }else if (LED_Command=="13N"){
        turnLedOn(LED_PIN13);
      }else if (LED_Command=="14N"){
        turnLedOn(LED_PIN14);
      }else if (LED_Command=="1OF"){
        turnLedOff(LED_PIN1);
      }else if (LED_Command=="2OF"){
        turnLedOff(LED_PIN2);
      }else if (LED_Command=="3OF"){
        turnLedOff(LED_PIN3);
      }else if (LED_Command=="4OF"){
        turnLedOff(LED_PIN4);
      }else if (LED_Command=="5OF"){
        turnLedOff(LED_PIN5);
      }else if (LED_Command=="6OF"){
        turnLedOff(LED_PIN6);
      }else if (LED_Command=="7OF"){
        turnLedOff(LED_PIN7);
      }else if (LED_Command=="8OF"){
        turnLedOff(LED_PIN8);
      }else if (LED_Command=="9OF"){
        turnLedOff(LED_PIN9);
      }else if (LED_Command=="10F"){
        turnLedOff(LED_PIN10);
      }else if (LED_Command=="11F"){
        turnLedOff(LED_PIN11);
      }else if (LED_Command=="12F"){
        turnLedOff(LED_PIN12);
      }else if (LED_Command=="13F"){
        turnLedOff(LED_PIN13);
      }else if (LED_Command=="14F"){
        turnLedOff(LED_PIN14);
      }
    }
  }
}
void turnLedOn(int pinNumber){
     digitalWrite(pinNumber,HIGH);
}
void turnLedOff(int pinNumber){
     digitalWrite(pinNumber,LOW);
}
