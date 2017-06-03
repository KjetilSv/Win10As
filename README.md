# Win10As
## Make your windows 10 computer IOT friendly

### Publish mqtt senors

#### Cpu prosessor load /cpuprosessortime
[maintopic]/cpuprosessortime returns string 0-100%
#### Free memory in MB /freememory
[maintopic]/freememory returns string of memory in MB
#### Volume muted
[maintopic]/mute 1=muted 0=not muted
#### Master volume in % volume
[maintopic]/volume returns string of current volume setting 0-100

### MQTT lisensers 
The predefined is optional due safety resons
#### Mute/Unmute
[maintopic]/mute/set 1=muted 0=not muted
published to [maintopic]/mute after setting
#### Volume
[maintopic]/volume/set volume 0-100
published to [maintopic]/volume after setting
#### Suspend PC
[maintopic]/suspend 
#### Shutdown
[maintopic]/shutdown
#### Reboot
[maintopic]/reboot
#### Hibrernate
[maintopic]/hibrernate
#### Toast message
[maintopic]/toast
Displays a message on the windows computer.
Message exsample "Home Assistant,kom ned!,Kjetil,c:\temp\iselin.jpg"
The the image must be visable from the windows computer.
#### TTS
[maintopic]/hibrernate
Mqtt message is sendt to the synthesizer.
Currently the volume is set to 100%
#### Custom commands
Message is optional
