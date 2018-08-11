using Windows.UI.Notifications;

namespace mqttclient
{
    public interface IToastMessage
    {
        void Show(string line1, string line2, string line3, string fileUri, ToastTemplateType ts);
    }
}