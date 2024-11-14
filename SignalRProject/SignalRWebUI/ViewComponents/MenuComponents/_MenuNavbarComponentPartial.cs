using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace SignalRWebUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarComponentPartial : ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
