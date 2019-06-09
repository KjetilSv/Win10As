using System;
using System.Collections.Generic;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace mqttclient
{
    public class ToastMessage : IToastMessage
    {
        private const string AppId = "Win Mqtt Client";

        public void ShowText(IList<string> lines)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText04);

            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            for (int i = 0; i < stringElements.Length; i++)
            {
                stringElements[i].AppendChild(toastXml.CreateTextNode(lines[i]));
            }

            ToastNotification toast = new ToastNotification(toastXml);
            toast.Activated += ToastActivated;
            toast.Dismissed += ToastDismissed;
            toast.Failed += ToastFailed;
            ToastNotificationManager.CreateToastNotifier(AppId).Show(toast);
        }
        public void ShowImage(IList<string> lines, string imageUrl)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            for (int i = 0; i < stringElements.Length; i++)
            {
                stringElements[i].AppendChild(toastXml.CreateTextNode(lines[i]));
            }

            String imagePath = "file:///" + imageUrl;

            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", imagePath);
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "alt text");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.Activated += ToastActivated;
            toast.Dismissed += ToastDismissed;
            toast.Failed += ToastFailed;
            ToastNotificationManager.CreateToastNotifier(AppId).Show(toast);
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
