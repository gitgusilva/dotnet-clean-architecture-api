using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return NotFound(new { message = "API está online!", status = "up", timestamp = DateTime.UtcNow });
        }
    }
}
