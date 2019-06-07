# Win 10 Assistant
## Make your windows 10 computer IOT friendly with MQTT

### Publish mqtt senors

#### Cpu prosessor load /cpuprosessortime
[maintopic]/cpuprosessortime 
returns string 0-100%
#### Free memory in MB /freememory
[maintopic]/freememory 
returns string of memory in MB
#### Volume muted
[maintopic]/mute 
1=muted 0=not muted
#### Master volume in % volume
[maintopic]/volume 
returns string of current volume setting 0-100
#### Camera Screnshot of primary monitor
if enabled it publishes to specified folder as jpg file or published the [maintopic]/mqttcamera topic
#### Battery sensors
if enabled published to [maintopic]/Power with subtopics
- BatteryChargeStatus
- BatteryFullLifetime
- BatteryLifePercent
- BatteryLifeRemaining
- PowerLineStatus
#### In use
[maintopic]/binary_sensor/inUse
Message "on" if the API GetLastInputInfo is less then 30 seconds else "off"

#### Disk sensors
[maintopic]/drive
Subtopic with each drive letter with the following subtopics
- totalsize
- percentFree
- availablefreespace

Exsample : kjetilsv/drive/c/totalsize

### MQTT listeners 
The predefined is optional due safety resons
#### Mute/Unmute
[maintopic]/mute/set 1=muted 0=not muted
published to [maintopic]/mute after setting
#### Volume
[maintopic]/volume/set volume 0-100
published to [maintopic]/volume after setting
#### Monitor
[maintopic]/monitor/set 0-1
published to [maintopic]/monitor after setting
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
Message exsample "Home Assistant,kom ned!,Kjetil,c:\temp\iselin.jpg".
The the image must be visable from the windows computer.
#### TTS
[maintopic]/tts
Mqtt message is sendt to the synthesizer.
Currently the volume is set to 100%
#### app/running sensor
[maintopic]/app/running/ message:[appname] and published back to [maintopic]/app/running/[appname] with 0= not running/not found in process 1= found
Tested with common applications like spotify/firefox/skype.
Exsample: 
mosquitto_pub -t kjetilsv/app/running -m Spotify
if spotify is running kjetilsv/app/running/Spotify return message = 1 
#### CMD
{"CommandString": "Chrome","WindowStyle": "1","ExecParameters": "http://vg.no","MonitorId": "1"}
#### Custom commands
[maintopic]/[customcommandname]
Message is currently not used, will be impemented in later versions.
One example of a custom command is lockcomputer. 
Thanks to @FatBasta it's no added in the hass-example file.
