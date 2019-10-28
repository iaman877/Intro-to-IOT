#include <ESP8266WiFi.h>
#include <FirebaseArduino.h>
#define FIREBASE_HOST "iot-task-2.firebaseio.com"                            //Your Firebase Project URL goes here without "http:" and "/"
#define FIREBASE_AUTH"HJCDhKaHDfknkxAkxkRxU"                      //Your Firebase Database Secret goes here
#define WIFI_SSID "Aman"                                                                                  //your WiFi SSID for which yout NodeMCU connects
#define WIFI_PASSWORD "aman12345678"                                             //Password of your wifi network 
#define Relay1 D5  
int rel1;
void setup() 
{
        Serial.begin(115200);                                                       // Select the same baud rate if you want to see the datas on Serial Monitor
        pinMode(Relay1,OUTPUT);
        digitalWrite(Relay1,HIGH);
       WiFi.begin(WIFI_SSID,WIFI_PASSWORD);
       Serial.print("connecting");
       while (WiFi.status()!=WL_CONNECTED){
       Serial.print(".");
      delay(500);
  } 
       Serial.println();
       Serial.print("connected:");
      Serial.println(WiFi.localIP());
       Firebase.begin(FIREBASE_HOST,FIREBASE_AUTH);
      Firebase.setInt("A1",0);                                 //Here the varialbe needs to be the one which is used in our Firebase and MIT App Inventor
}
void firebasereconnect()
{
       Serial.println("Trying to reconnect");
      Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
  }
void loop() 
{
            rel1=Firebase.getString("A1").toInt();        //Reading the value of the varialble Status from the firebase
           if(rel1==1)                                                                   // If, the Status is 1, turn on the Relay1
     {
          digitalWrite(Relay1,LOW);
          Serial.println("Relay 1 OFF");
    }
 if(rel1==0)                                                                  // If, the Status is 0, turn Off the Relay1
    {                                      
           digitalWrite(Relay1,HIGH);
           Serial.println("Relay 1 ON");
    }
 }
