using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PiInfoService.Info;

namespace PiInfoService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PiInfoController : ControllerBase
    {
        private readonly ILogger<PiInfoController> _logger;

        public PiInfoController(ILogger<PiInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(new ServiceAbout());
        }

        [HttpGet("Date")]
        public ActionResult Date()
        {
            return Ok(new { date = PiInfo.Date });
        }

        [HttpGet("Time")]
        public ActionResult Time()
        {
            return Ok(new { time = PiInfo.Time });
        }

        [HttpGet("DateTime")]
        public ActionResult CurrentDateTime()
        {
            return Ok(new { dateTime = PiInfo.CurrentDateTime });
        }

        [HttpGet("CPUTemp")]
        public ActionResult<double> CPUTemperature()
        {
            double temp;

            try
            {
                temp = PiInfo.GetTemp();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }

            return Ok(new { CPUTemp = temp });
        }

        [HttpGet("IP")]
        public ActionResult<string> IP()
        {
            string ip;

            try
            {
                ip = PiInfo.GetIp();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }

            return Ok(new { ip = ip });
        }
    }
}
