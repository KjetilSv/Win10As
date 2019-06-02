using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace mqttclient.HardwareSensors
{
    public class Monitor
    {
        private class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        }

        private const int WmSyscommand = 0x0112;
        private const int ScMonitorpower = 0xF170;
        private const int MonitorTurnOn = -1;
        private const int MonitorShutoff = 2;

        public static void TurnOn()
        {
            using (var f = new Form())
            {
                NativeMethods.SendMessage(f.Handle, WmSyscommand, (IntPtr)ScMonitorpower,
                    (IntPtr)MonitorTurnOn);
            }
        }

        public static void TurnOff()
        {
            using (var f = new Form())
            {
                NativeMethods.SendMessage(f.Handle, WmSyscommand, (IntPtr)ScMonitorpower,
                    (IntPtr)MonitorShutoff);
            }
        }
    }
}
