namespace mqttclient.HardwareSensors
{
    public static class UsingComputer
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
