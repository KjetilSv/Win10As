
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
using System.Drawing.Imaging;

namespace mqttclient.HardwareSensors
{
    public class Camera

    {
        private VideoCaptureDevice FinalVideo;
        public string Filename { get; set; }
        public MemoryStream memoryStream = new MemoryStream();
        public string GetPicture(string WebcamnameId)

        {
            try
            {
                if (Filename != null)
                {
                    bool finish = false;
                    File.Delete(Filename);

                    FilterInfoCollection VideoCaptureDev = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                    foreach (FilterInfo VideoCaptureDevice in VideoCaptureDev)
                    {

                        if (VideoCaptureDevice.Name == WebcamnameId)
                        {
                            FinalVideo = new VideoCaptureDevice(VideoCaptureDevice.MonikerString);
                        }
                    }



                    FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                   // FinalVideo.FramesReceived
                    FinalVideo.Start();
                    do
                    {
                        FinalVideo.Start();
                        if (File.Exists(Filename))
                        //if (memoryStream.Length != 0)
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
            catch (Exception)
            {

                throw;
            }

        }
        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {

                //using (FileStream stream = new FileStream(Filename + "1", FileMode.OpenOrCreate, FileAccess.Write))
                //{

                //}
                //using (FileStream stream = new FileStream(Filename, FileMode.OpenOrCreate, FileAccess.Write))
                //{
                //FileStream stream = new FileStream;


               Bitmap bitmap= (Bitmap)eventArgs.Frame;
                // (Bitmap)eventArgs.Frame.Save(Filename, System.Drawing.Imaging.ImageFormat.Png);
                //Bitmap bitmap = ();
                //Bitmap bitclone = (Bitmap)bitmap.Clone();
                bitmap.Save(Filename, System.Drawing.Imaging.ImageFormat.Png);
                //bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                //stream.CopyTo(memoryStream);
                bitmap.Dispose();

                //}

            }
            catch (Exception)
            {

                throw;
            }


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
