using System;

namespace PiInfoService.Info
{
    public class PiInfo
    {
        public static string Date => DateTime.Now.ToString(ConstVals.DateFormat);
        public static string Time => DateTime.Now.ToString(ConstVals.TimeFormat);
        public static string CurrentDateTime => Date + "T" + Time;

        public static double GetTemp()
        {
            return Hardware.GetDoubleTemp();
        }

        public static string GetIp()
        {
            return Software.GetIpAddress();
        }
    }
}