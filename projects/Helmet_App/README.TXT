This app is a direct interface to control my helmet (see main/projects/3D_Modeling/Elbrandir/HELMET
or main/projects/Arduino/HELMET for reference).

The primary functions of this application are to control the eye movements, display text, and use
Google API to receive speech-to-text and act as a universal translator. If you go into the
REFERENCE_IMAGES folder and click on App_Screenshot.jpg, you will be able to see the mobile
application view.

In order from top to bottom:

1. Connect Bluetooth
-The helmet has a serial bluetooth module connected to an Arduino. The bluetooth module receives
data from the phone application to display across its custom-built see-through LED matrix visor.

2. Text Box / Submit / Clear
-Whatever is typed into this text box will be sent to the helmet, which will display the text on
its LED matrix visor. The text will scroll, so there is no limit to the amount of text displayed.
Once sent, the text stays within the text box on the app, allowing for the data to be re-sent
unless cleared.

3. Translate
-Using Google API, this app acts as a universal translator. To specify, it can translate spoken
English into any other language. It does not work in reverse. Any sentence that is submitted
into the above text field will be translated into the selected language before being sent to
the helmet (the user must press Submit to send the text data to the helmet).

4. Pitch / Speed / AutoSpeech
-Using Google API, this app can receive spoken speech and transcribe it into text. In addition,
the app can also do the reverse- once the text field (or transcribed speech) is sent to the
helmet, a synthesized voice will speak the text in the language specified by the universal
translator. The Pitch/Speed alter the tone/pace of the synthesized voice respectively.
The helmet also has a speaker and auxilary 3.5mm cable connector, allowing for the phone to
output the synthesized voice through the helmet's speaker.
Lastly, the AutoSpeech toggle allows for instant sending of speech transcription. This means
once you have a language selected, pressing the blue button to the right of the AutoSpeech
toggle will automatically transcribe your spoken speech, translate it to the desired language,
then automatically send the transcription data to the helmet and output the text-to-speech
in the synthesized voice through the helmet's speaker.

5. Track / ASA / Toggle
-This is a deprecated functionality of the helmet. There were eye-tracking sensors inside the
helmet to mimic the user's eye movements on the helmet's LED matrix visor; however, the eye-
tracking was not as accurate as initial tests showed, as when the helmet is worn, the light
reflecting off the eyes is not enough for the eye motion sensors to identify. Thus, the eye
motion tracking functionality for the helmet has been removed.
As for ASA (Array Set Addressing), the helmet has a microphone embedded within. The intial
conception for using the microphone was to receive sound, such as a voice or music, and
display a FFT LED visualizer on the LED matrix visor. However, the Arduino used for the
helmet lacked the functionality to process the microphone's sound signal, so the ASA/Toggle
buttons became deprecated.

6. EYES
-By default, upon startup and immediately after text has finished scrolling across the visor,
the LED matrix visor displays two eyes. Each of the four buttons shows different eye
expressions, which can be immediately changed at a single press of a button.

7. Touchpad Joystick
-Allowing for minimal focus requirements, the touchpad joystick allows the user to move the
helmet's eyes on the LED matrix visor left and right by moving the joystick left/right
respectively. Additionally, moving the joystick down allows the eyes to blink, and if the
joystick is held down, the eyes remain closed until the finger is released. Moving the
joystick upward does nothing.