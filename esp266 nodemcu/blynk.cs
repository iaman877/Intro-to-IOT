#define BLYNK_PRINT Serial 
#include <ESP8266WiFi.h> 
#include <BlynkSimpleEsp8266.h> 
char auth[]="8833037f8668491f83180b7b3cb6e793"; 
char ssid[]="Aman"; 
char pass[]="aman12345678"; 
   void setup()
        { 
            Serial.begin(115200); 
           Blynk.begin(auth , ssid , pass ); 
      }  
  void loop()
    { 
         Blynk.run(); 
   }
