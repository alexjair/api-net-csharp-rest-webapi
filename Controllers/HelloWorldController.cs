using api_net_csharp_rest_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_net_csharp_rest_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HelloWorldController: ControllerBase
    {
        public HelloWorldController(
            IHelloWorldService _helloWorldService,
            ILogger<WeatherForecastController> logger
        )
        {
            _logger = logger;
            helloWorldService = _helloWorldService;
        }

        IHelloWorldService helloWorldService;
        //Log - seguimiento
        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("[ Log -> ] Retorno saludo (Get).");
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}
