using Microsoft.AspNetCore.Mvc;

namespace MyApi.Presentation.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("API está online");
        }
    }
} 