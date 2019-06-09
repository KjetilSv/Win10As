namespace mqttclient.HardwareSensors
{
    public static class UsingComputer
    {
        public static bool IsUsing()
        {
            if (GetIdleTime() > 30)
            {
                return false;
            }
            return true;
        }

        public static int GetIdleTime()
        {
            var idleTime = IdleTimeFinder.GetIdleTime();
            return (int)idleTime.TotalSeconds;
        }
    }
}
