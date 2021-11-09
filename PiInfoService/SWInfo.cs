using System;
using System.Diagnostics;

namespace PiInfoService
{
    public static class SWInfo
    {
        private static ProcessStartInfo IPProcessInfo = new ProcessStartInfo()
        {
            FileName = "hostname",
            Arguments = "-I",
            RedirectStandardOutput = true,
            CreateNoWindow = false
        };

        public static string GetIpAddress()
        {
            string ip;

            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo = IPProcessInfo;
                    proc.Start();

                    ip = proc.StandardOutput.ReadToEnd();
                    proc.WaitForExit();
                }

                ip = ip.Replace("\n", "");
                ip = ip.Trim();
            }
            catch
            {
                throw;
            }

            return ip;
        }
    }
}