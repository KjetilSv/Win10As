using Autofac;
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

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                FrmMqttMain form1 = scope.Resolve<FrmMqttMain>();
                Application.ThreadException += new ThreadExceptionEventHandler(form1.UnhandledThreadExceptionHandler);
                Application.Run(form1);
            }


        }
    }
}