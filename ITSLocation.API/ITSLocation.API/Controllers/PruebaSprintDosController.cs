using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITSLocation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaSprintDosController : ControllerBase
    {
        private static readonly string[] resultados = new[]
        {
            "Hola", "Buenas", "Tardes", "This ", "is", "the", "real", "shit", "dog"
        };

        private readonly ILogger<PruebaSprintDosController> _logger;

        public PruebaSprintDosController(ILogger<PruebaSprintDosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRegards")]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                _logger.LogInformation("Esto fue una prueba satisfactoria.");
                _logger.LogError("Esto fue una prueba erronea pruebas.");
                _logger.LogInformation("Esto fue una prueba satisfactoria.");
                _logger.LogError("Esto fue una prueba erronea pruebas.");
                _logger.LogInformation("Esto fue una prueba satisfactoria.");
                _logger.LogError("Esto fue una prueba erronea pruebas.");
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = resultados[Random.Shared.Next(resultados.Length)]
                })
            .ToArray();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }            
        }
    }
}
