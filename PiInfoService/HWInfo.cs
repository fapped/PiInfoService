using System;
using System.Diagnostics;

namespace PiInfoService
{
    public static class HWInfo
    {
        private static ProcessStartInfo CPUTempStartInfo = new ProcessStartInfo()
        {
            FileName = "cat",
            Arguments = "/sys/class/thermal/thermal_zone0/temp",
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        public static string GetRawTemp()
        {
            string temperature;

            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo = CPUTempStartInfo;
                    proc.Start();

                    temperature = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();
                }
            }
            catch
            {
                throw;
            }

            return temperature;
        }

        public static int GetIntTemp()
        {
            string strTemp = GetRawTemp();
            int temperature;

            if (int.TryParse(strTemp, out temperature) == false)
                throw new InvalidCastException(nameof(GetIntTemp));

            return temperature;
        }

        public static double GetDoubleTemp()
        {
            int intTemp = GetIntTemp();
            double temperature = intTemp / 1000.0;

            return temperature;
        }
    }
}