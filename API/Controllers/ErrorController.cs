using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
