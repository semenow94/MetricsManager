using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ValuesHolder holder;

        public WeatherForecastController(ValuesHolder holder)
        {
            this.holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime date, [FromQuery] int temperature)
        {
            holder.Add(date, temperature);
            return Ok(holder.requestStatus);
        }

        [HttpGet]
        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(holder.Values);
        }

        [HttpPost("update")]
        public IActionResult Delete([FromQuery] DateTime date, [FromQuery] int temperature)
        {
            holder.Update(date, temperature);
            return Ok(holder.requestStatus);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            holder.Delete(date);
            return Ok(holder.requestStatus);
        }
    }
}
