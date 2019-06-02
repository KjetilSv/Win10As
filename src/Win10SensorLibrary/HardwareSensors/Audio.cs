using System;
using System.Collections.Generic;
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
        static public List<string> GetAudioDevices()
        {
            CoreAudioController cac = new CoreAudioController();
            List<string> tmp = new List<string>();

            foreach (CoreAudioDevice de in cac.GetPlaybackDevices())
            {
                tmp.Add(de.FullName);
            }

            return tmp;

        }
        public void ChangeOutputDevice(string DeviceFullname)
        {
            CoreAudioController cac = new CoreAudioController();
            foreach (CoreAudioDevice de in cac.GetPlaybackDevices())
            {
                if (de.FullName.ToLower() == DeviceFullname.ToLower())
                {
                    defaultPlaybackDevice = de;
                }

            }
        }
    }
}