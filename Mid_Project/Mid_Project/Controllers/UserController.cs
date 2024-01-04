using Microsoft.AspNetCore.Mvc;

namespace Mid_Project.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
