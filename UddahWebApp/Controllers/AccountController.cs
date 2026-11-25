using Microsoft.AspNetCore.Mvc;

namespace UddahWebApp.Controllers
{
    // account page: shows the cookies and the session values
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            // read the session values and send them to the view
            ViewBag.sessionId = HttpContext.Session.GetString("id");
            ViewBag.sessionUserName = HttpContext.Session.GetString("username");
            return View();
        }
    }
}