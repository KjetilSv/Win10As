using System;
using System.Threading;
using System.Windows.Forms;

namespace mqttclient
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmMqttMain form1 = new FrmMqttMain();
            Application.ThreadException += new ThreadExceptionEventHandler(form1.UnhandledThreadExceptionHandler);
            Application.Run(form1);
        }
    }
}
