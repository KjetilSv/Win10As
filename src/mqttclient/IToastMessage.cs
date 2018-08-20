using System.Collections.Generic;
using Windows.UI.Notifications;

namespace mqttclient
{
    public interface IToastMessage
    {
        void ShowText(IList<string> lines);
        void ShowImage(IList<string> lines, string imageUrl);
    }
}