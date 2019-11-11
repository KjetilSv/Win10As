using System;
using System.Windows.Forms;

namespace mqttclient
{
    public class Logger : ILogger
    {
        private readonly MainFormContainer _mainFormContainer;

        public Logger(MainFormContainer mainFormContainer)
        {
            _mainFormContainer = mainFormContainer;
        }

        public void Log(string message)
        {
            try
            {
                var mainForm = _mainFormContainer.MainForm;
                mainForm.Invoke((MethodInvoker)(() => mainForm.txtLoger.Text = message + "\n " + mainForm.txtLoger.Text));


                
                //mainForm.te

                //if (mainForm.listBox1.Items.Count > 20)
                //{
                //    mainForm.Invoke((MethodInvoker)(() => mainForm.listBox1.Items.RemoveAt(20)));
                //}
            }
            catch (Exception)
            {
                // throw;
            }
        }
    }
}
