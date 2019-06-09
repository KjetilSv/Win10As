
using System;
using System.Collections.Generic;
using System.Drawing;
using AForge.Video.DirectShow;
using Emgu.CV;

namespace mqttclient.HardwareSensors
{
    public static class Camera
    {
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
        public static Boolean Save(string FileName)
        {
            try
            {
                VideoCapture capture = new VideoCapture(0);
                Bitmap image = capture.QueryFrame().Bitmap;
                image.Save(FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                capture.Dispose();
                image.Dispose();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
