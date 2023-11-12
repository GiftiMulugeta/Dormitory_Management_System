using Microsoft.AspNetCore.Mvc;

namespace Student.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
