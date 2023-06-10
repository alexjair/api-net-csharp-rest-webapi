using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading;

namespace api_net_csharp_rest_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaDataController : ControllerBase
    {
        public ListaDataController(
            ILogger<WeatherForecastController> logger
        ){
            _logger = logger;

            if (dtlista == null || !dtlista.Any())
            {
                dtlista = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();
            }           
        }

        private static readonly string[] Summaries = new[]{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static List<WeatherForecast> dtlista = new List<WeatherForecast>();
        //Log - seguimiento
        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet]
        [Route("[action]")]
        //[Route("lista")]
        //[Route("lista-v2")]
        //[Route("[action]")] //Usa el nombre del metodo en la ruta
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("[ Log -> ] Retorno de información de la lista WeatherForecast (Get).");
            //_logger.LogDebug("[ Log -> ] Retorno de información de la lista WeatherForecast (Get).");
            return dtlista;
        }

        [HttpPost]
        [Route("[action]")]
        //[Route("agregar")]
        public IActionResult Post(WeatherForecast objRow)
        {
            _logger.LogInformation("[ Log -> ] Agregar registro a lista (Post).");
            dtlista.Add(objRow);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("eliminar/{index:int}")]
        public IActionResult Delete(int index) //solo se usa el indice
        {
            _logger.LogInformation("[ Log -> ] Delete registro de la lista (Delete).");
            dtlista.RemoveAt(index);
            return Ok();
        }



    }
}
