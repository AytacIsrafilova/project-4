using Microsoft.AspNetCore.Mvc;

namespace Exam_example.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
       
        public IActionResult Login()
        {
            return View();
        }
    }
}
