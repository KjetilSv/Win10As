using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DirectShowLib;
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
        public string GetPicture(string Webcamname)
        {

            bool finish = false;
            string filename = @"c:\temp\picture.jpg";

            File.Delete(filename);
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[1].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();
            do
            {
                if (File.Exists(filename))
                {
                    finish = true;
                    FinalVideo.SignalToStop();
                 }
            } while (finish != true);
            return filename;

        }
        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
 
            Bitmap bitmap = (Bitmap)eventArgs.Frame;
            bitmap.Save(@"C:\temp\picture.jpg");

        }
        public List<string> GetDevices()
        {
            List<string> Result = new List<string>();
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                Result.Add(VideoCaptureDevice.Name);
            }

            return Result;
        }
    }
}
