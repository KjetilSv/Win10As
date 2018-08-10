using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace mqttclient
{
    public class ToastMessage
    {
        private const string appID = "Win Mqtt Client";

        private void Toastmessage(string line1, string line2, string line3, string fileUri, ToastTemplateType ts)
        {
            switch (ts)
            {
                case ToastTemplateType.ToastImageAndText04:

                    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

                    string tempLine = "";

                    XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
                    for (int i = 0; i < stringElements.Length; i++)
                    {

                        switch (i)
                        {
                            case 0:
                                tempLine = line1;
                                break;
                            case 1:
                                tempLine = line2;
                                break;
                            case 2:
                                tempLine = line3;
                                break;
                        }
                        stringElements[i].AppendChild(toastXml.CreateTextNode(tempLine));
                    }

                    String imagePath = "file:///" + fileUri;

                    XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
                    ((XmlElement)toastImageAttributes[0]).SetAttribute("src", imagePath);
                    ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "alt text");

                    ToastNotification toast = new ToastNotification(toastXml);
                    toast.Activated += ToastActivated;
                    toast.Dismissed += ToastDismissed;
                    toast.Failed += ToastFailed;
                    ToastNotificationManager.CreateToastNotifier(appID).Show(toast);
                    break;

                default:
                    break;

            }
        }
        private void ToastFailed(ToastNotification sender, ToastFailedEventArgs args)
        {
            throw new NotImplementedException();
        }
        private void ToastDismissed(ToastNotification sender, ToastDismissedEventArgs args)
        {
            throw new NotImplementedException();
        }
        private void ToastActivated(ToastNotification sender, object args)
        {
            throw new NotImplementedException();
        }
    }
}
