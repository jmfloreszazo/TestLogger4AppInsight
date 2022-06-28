using Microsoft.AspNetCore.Mvc;
using TestLogger4AppInsight;

namespace TestLoggerWithWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICustomLogger _logger;

        public WeatherForecastController(ICustomLogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string WeatherForecast()
        {
            _logger.Exception(new Exception(">>>> Logger Exception >> Test exception message"));
            _logger.Verbose(">>>> Logger Verbose >> Test Endpoint Get");
            _logger.Information(">>>> Logger Information >> Test Endpoint Get");

            return "En Test";
        }
    }
}