using Microsoft.AspNetCore.Mvc;

namespace StajProject2.ViewComponents.Default
{
    public class _Navbar: ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
