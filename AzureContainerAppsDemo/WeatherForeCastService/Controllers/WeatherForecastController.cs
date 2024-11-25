using Microsoft.AspNetCore.Mvc;

namespace WeatherForeCastService.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Cities = new[]
        {
            "Kolkata", "Bengaluru", "Chennai", "Delhi", "Shrirampur", "Ahmedabad"
        };

        private static readonly string[] Summaries = new[]
                {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this._logger = logger;
        }

        [HttpGet("cities")]
        public IEnumerable<string> GetCities()
        {
            _logger.LogInformation($"Prateek : {nameof(GetCities)} called at {DateTime.UtcNow}");
            return Cities;
        }

        [HttpGet("error")]
        public string GetError()
        {
            try
            {
                throw new Exception("An exception is raised");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Prateek : Error Raised at {nameof(GetError)} {DateTime.UtcNow} {ex.Message} {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet("details")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            _logger.LogInformation($"Prateek : {nameof(GetWeatherForecast)} called at {DateTime.UtcNow}");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
