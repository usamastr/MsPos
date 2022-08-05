using Microsoft.AspNetCore.Mvc;

namespace MsPos.Controllers
{
    public class Management : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
