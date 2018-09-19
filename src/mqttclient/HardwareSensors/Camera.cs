
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using AForge.Video.DirectShow;
using AForge.Video;
using System.IO;

namespace mqttclient.HardwareSensors
{
    public class Camera
    {
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        public string Filename { get; set; }
        public string GetPicture(string WebcamnameId)
        {
            if (Filename != null)
            {
                bool finish = false;
                File.Delete(Filename);

                FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[Convert.ToInt32(WebcamnameId)].MonikerString);
                FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                FinalVideo.Start();
                do
                {
                    if (File.Exists(Filename))
                    {
                        finish = true;
                        FinalVideo.SignalToStop();
                    }
                } while (finish != true);
                return Filename;

            }
            else
            {
                return "";
            }
        }
        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            Bitmap bitmap = (Bitmap)eventArgs.Frame;
            bitmap.Save(Filename);

        }
        public static List<string> GetDevices()
        {
            List<string> Result = new List<string>();
            FilterInfoCollection VideoCaptureDev = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDev)
            {
                Result.Add(VideoCaptureDevice.Name);
            }

            return Result;
        }
    }
}
