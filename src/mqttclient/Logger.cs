using System;
using System.Windows.Forms;

namespace mqttclient
{
    public class Logger : ILogger
    {
        private readonly FrmMqttMain _frmMqttMain;

        public Logger(FrmMqttMain frmMqttMain)
        {
            _frmMqttMain = frmMqttMain;
        }

        public void Log(string message)
        {
            try
            {
                _frmMqttMain.Invoke((MethodInvoker)(() => _frmMqttMain.listBox1.Items.Insert(0, message)));
                if (_frmMqttMain.listBox1.Items.Count > 20)
                {
                    _frmMqttMain.Invoke((MethodInvoker)(() => _frmMqttMain.listBox1.Items.RemoveAt(20)));
                }
            }
            catch (Exception)
            {
                // throw;
            }
        }
    }
}
