using System;

namespace PiInfoService
{
    public class ServiceAbout
    {
        public string About => "PiInfoService v0.01 " + DateTime.Now.ToString($"{ConstVals.DateFormat} {ConstVals.TimeFormat}");
    }
}