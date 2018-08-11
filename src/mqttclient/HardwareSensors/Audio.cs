using System;
using AudioSwitcher.AudioApi.CoreAudio;

namespace mqttclient.HardwareSensors
{
    public class Audio : IAudio
    {
        CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;

        public void Mute(Boolean Enable)
        {
            try
            {
                defaultPlaybackDevice.Mute(Enable);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public Boolean IsMuted()
        {
            try
            {
                return defaultPlaybackDevice.IsMuted;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void Volume(int level)
        {
            try
            {
                defaultPlaybackDevice.Volume = Convert.ToDouble(level);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public string GetVolume()
        {
            try
            {
                return defaultPlaybackDevice.Volume + "%";
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}