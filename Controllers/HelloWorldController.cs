using api_net_csharp_rest_webapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_net_csharp_rest_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HelloWorldController: ControllerBase
    {
        public HelloWorldController(
            IHelloWorldService _helloWorldService,
            ILogger<WeatherForecastController> logger,
            TareasContext _tareasContext
        )
        {
            _logger = logger;
            helloWorldService = _helloWorldService;
            dbcontext = _tareasContext;
        }

        IHelloWorldService helloWorldService;
        TareasContext dbcontext;

        //Log - seguimiento
        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("[ Log -> ] Retorno saludo (Get).");
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDB()
        {
            _logger.LogInformation("[ Log -> ] Se creo la DB.");
            dbcontext.Database.EnsureCreated(); 
            return Ok();
        }
    }
}
