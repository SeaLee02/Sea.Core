using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sea.Core.Entity;
using Sea.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sea.Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        MyDbContext _myDbContext;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;


        private readonly ExmailHelper _exmailHelper;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDbContext myDbContext, ExmailHelper exmailHelper)
        {
            _logger = logger;
            _myDbContext = myDbContext;
            this._exmailHelper = exmailHelper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Console.WriteLine("---------------");
            Console.WriteLine(this._exmailHelper.GetHashCode());
            Console.WriteLine(this._exmailHelper.Email_token);


            var list= this._myDbContext.UserEntitys.FirstOrDefault(x=>x.Id== "dwqdwq");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
