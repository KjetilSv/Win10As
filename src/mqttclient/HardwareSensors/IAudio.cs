namespace mqttclient.HardwareSensors
{
    public interface IAudio
    {
        string GetVolume();
        bool IsMuted();
        void Mute(bool Enable);
        void Volume(int level);
    }
}