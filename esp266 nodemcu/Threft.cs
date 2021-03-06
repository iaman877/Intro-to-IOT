#define BLYNK_PRINT Serial
#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266.h>
BlynkTimer timer;
char auth[] = " xxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
char ssid[] = "Aman";
char pass[] = "aman12345678";
int flag=0;
void notifyOnButtonPress()
       {
              int isButtonPressed = digitalRead(D1);
              if (isButtonPressed==1 && flag==0) {
              Serial.println("Someone Opened the door");
              Blynk.notify("Alert : Someone Opened the door");
                flag=1;
      }
       else if (isButtonPressed==0)
          {
                 flag=0;
         }
   }
      void setup()
         {
          Serial.begin(9600);
          Blynk.begin(auth, ssid, pass);
           pinMode(D1,INPUT_PULLUP);
           timer.setInterval(16000L,notifyOnButtonPress);
 }
  void loop()
  {
        Blynk.run();
        timer.run(); // Initiates BlynkTimer
}
