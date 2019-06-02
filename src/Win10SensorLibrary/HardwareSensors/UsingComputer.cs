namespace mqttclient.HardwareSensors
{
    public class UsingComputer
    {
        public static bool IsUsing()
        {
            var idleTime = IdleTimeFinder.GetIdleTime();
            if (idleTime.TotalSeconds > 30)
            {
                return false;
            }
            return true;
        }
    }
}
