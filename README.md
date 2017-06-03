# Win10As
## Make your windows 10 computer IOT friendly

###### Publish mqtt senors

- Cpu prosessor load /cpuprosessortime
[maintopic]/cpuprosessortime returns string 0-100%

- Free memory in MB /freememory
  [maintopic]/freememory returns string of memory in MB
- Volume muted
    [maintopic]/mute 1=muted 0=not muted
- Master volume in % volume
    [maintopic]/volume returns string of current volume setting 0-100
Optional MQTT lisensers
- Mute/Unmute
- Volume
- Suspend PC
- Shutdown
- Toast message
- TTS
- Reboot
- Hibrernate
- Custom commands

Download beta version https://github.com/KjetilSv/Win10As/raw/master/mqtt.zip
