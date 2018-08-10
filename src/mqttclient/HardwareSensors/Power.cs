namespace mqttclient
{
    public class Power
    {

        public static string BatteryChargeStatus()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
        }


        public static string BatteryFullLifetime()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryFullLifetime.ToString();
        }

        public static string BatteryLifePercent()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryLifePercent.ToString();
        }

        public static string BatteryLifeRemaining()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.BatteryLifeRemaining.ToString();
        }

        public static string PowerLineStatus()
        {
            return System.Windows.Forms.SystemInformation.PowerStatus.PowerLineStatus.ToString();
        }

    }
}