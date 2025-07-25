using Microsoft.AspNetCore.Mvc;

namespace MyApi.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
} 