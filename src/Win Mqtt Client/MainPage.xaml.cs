using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Win_Mqtt_Client
{

    public sealed partial class MainPage : Page
    {
        private string appID = "Win Mqtt Client";
        MqttClient client;
        ThreadPoolTimer PeriodicTimer;
        int period = 1000;
       // BindingList<mqtttrigger> MqttTriggerList = new BindingList<mqtttrigger>();

        public string g_mqtttopic { get; set; }
        public string g_TriggerFile { get; set; }
        public string g_LocalScreetshotFile { get; set; }

        public MainPage()
        {
            ThreadPoolTimer.CreatePeriodicTimer(ExampleTimerElapsedHandler, TimeSpan.FromMilliseconds(period));
            this.InitializeComponent();
        }
        private string SetSubTopic(string Topic)
        {
            return g_mqtttopic.Replace("#", Topic);
        }
        private void ExampleTimerElapsedHandler(ThreadPoolTimer timer)
        {
           // MqttPublish(SetSubTopic("cpuprosessortime"), HardwareSensors.GetCpuProsessorTime());
            //throw new NotImplementedException();
        }
        private void MqttPublish(string topic, string message)
        {
            if (client.IsConnected == true)
            {
                client.Publish(topic, Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
