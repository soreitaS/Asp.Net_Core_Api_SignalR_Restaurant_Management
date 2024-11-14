using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class UIAboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
