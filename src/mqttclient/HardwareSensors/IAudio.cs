using System.Collections.Generic;

namespace mqttclient.HardwareSensors
{
    public interface IAudio
    {
        string GetVolume();
        bool IsMuted();
        void Mute(bool Enable);
        void Volume(int level);
        List<string> GetAudioDevices();
        void ChangeOutputDevice(string DeviceFullname);
    }
}