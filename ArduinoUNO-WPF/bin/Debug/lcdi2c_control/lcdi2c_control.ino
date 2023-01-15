#include <LiquidCrystal_I2C.h> 
LiquidCrystal_I2C lcd(0x27, 16, 2); 
byte alien[8] = { 
	0b01010,
	0b11111,
	0b10101,
	0b11111,
	0b11111,
	0b01010,
	0b01010,
	0b11011
}; 
byte check[8] = { 
	0b00000,
	0b00001,
	0b00011,
	0b10110,
	0b11100,
	0b01000,
	0b00000,
	0b00000
}; 
byte heart[8] = { 
	0b00000,
	0b01010,
	0b11111,
	0b11111,
	0b01110,
	0b00100,
	0b00000,
	0b00000
}; 
byte krst[8] = { 
	0b00100,
	0b00100,
	0b11111,
	0b00100,
	0b00100,
	0b00100,
	0b00100,
	0b00100
}; 
byte skull[8] = { 
	0b00000,
	0b01110,
	0b10101,
	0b11011,
	0b01110,
	0b01110,
	0b00000,
	0b00000
}; 
byte speaker[8] = { 
	0b00001,
	0b00011,
	0b01111,
	0b01111,
	0b01111,
	0b00011,
	0b00001,
	0b00000
}; 

String inputString;
String message;
void setup() {
	Serial.begin(9600);
	Serial.setTimeout(10);
	lcd.init();
	lcd.clear();
	lcd.createChar(0,alien);
	lcd.createChar(1,check);
	lcd.createChar(2,heart);
	lcd.createChar(3,krst);
	lcd.createChar(4,skull);
	lcd.createChar(5,speaker);

} 
void loop() { 
	lcd.noCursor();
	lcd.noBlink();
	if (Serial.available() > 0) {
	String inputString = Serial.readString();
	if (inputString.startsWith("$Values_")) {
		int index = inputString.substring(8, inputString.indexOf("_", 8)).toInt();
		int value1 = inputString.substring(inputString.indexOf("_", 8) + 1, inputString.indexOf("_", inputString.indexOf("_", 8) + 1)).toInt();
		int value2 = inputString.substring(inputString.indexOf("_", inputString.indexOf("_", 8) + 1) + 1).toInt();
	lcd.setCursor(value1, value2);
		lcd.write(index);
	}
	else if (inputString.startsWith("$Text_")) {
		int value3 = inputString.substring(6, inputString.indexOf("_", 6)).toInt();
		String text = inputString.substring(inputString.indexOf("_", 6) + 1);
		lcd.setCursor(0, value3);
		lcd.print(text);
	}
	else if (inputString.startsWith("$Clear")){
		lcd.clear();
	}
}
}
