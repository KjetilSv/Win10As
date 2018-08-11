using System.Linq;
using System.Reflection;
using Autofac;
using mqttclient.HardwareSensors;
using uPLibrary.Networking.M2Mqtt;

namespace mqttclient
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Mqtt>().As<IMqtt>().SingleInstance();
            builder.RegisterType<MqttPublish>().As<IMqttPublish>();
            builder.RegisterType<Audio>().As<IAudio>();
            builder.RegisterType<ToastMessage>().As<IToastMessage>();
            builder.RegisterType<FrmMqttMain>().AsSelf().SingleInstance();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(mqttclient)))
            //    .Where(t => t.Namespace.Contains("HardwareSensors"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
