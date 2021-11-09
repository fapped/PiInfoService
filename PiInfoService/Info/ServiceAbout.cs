using System;

namespace PiInfoService.Info
{
    public class ServiceAbout
    {
        public string About => "PiInfoService v0.01 " + DateTime.Now.ToString($"{ConstVals.DateFormat} {ConstVals.TimeFormat}");
    }
}