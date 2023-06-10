using api_net_csharp_rest_webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_net_csharp_rest_webapi.Controllers
{
    public class CategoriaController : ControllerBase
    {
        ICategoriaService categoriaService;
        
        public CategoriaController(
            ICategoriaService _icategoriaService
        ){ 
            categoriaService = _icategoriaService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            return Ok(categoriaService.Get());
        }
                

    }
}
