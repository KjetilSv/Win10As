using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace mqttclient.HardwareSensors
{
    class Speaker
    {
        public static List<string> GetSpeakers()
        {
            List<string> result = new List<string>() ;
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                foreach (InstalledVoice i in synthesizer.GetInstalledVoices())
                {
                    result.Add((i.VoiceInfo.Name));
                }
            return result;
        }

        public static void Speak(string Text,string Device)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoice(Device);
            synthesizer.Speak(Text);
        }
    }
}
