using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UddahWebApp.Models;

namespace UddahWebApp.Controllers
{
    public class HomeController : Controller
    {
        // creates a cookie in the user's browser
        public IActionResult SetCookies(string cookieName, string cookieValue)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(15),   // cookie expires in 15 days
                HttpOnly = true,                      // javascript can not read the cookie
                Secure = true,                        // only sent with https
                SameSite = SameSiteMode.Strict        // prevent CSRF attacks
            };
            Response.Cookies.Append(cookieName, cookieValue, options);
            return Ok("Cookies has been set.");
        }

        // saves a value in the session on the server
        public IActionResult SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
            return RedirectToAction("Index");
        }

        // home page: creates the cookies and the session every time the user opens it
        public IActionResult Index()
        {
            // create a session id
            SetSession("id", Guid.NewGuid().ToString());

            // check if the user is logged in
            if (User.Identity.IsAuthenticated)
            {
                // user is logged in, save his name in a cookie and in the session
                SetCookies("userName", User.Identity.Name);
                SetSession("username", User.Identity.Name);
            }
            else
            {
                // user is not logged in, save "guest"
                SetCookies("userName", "guest");
                SetSession("username", "guest");
            }

            // save the browser type and the time of the last visit in cookies
            SetCookies("browserName", Request.Headers["User-Agent"].ToString());
            SetCookies("lastVisit", DateTime.Now.ToString());

            return View();
        }

        // each method opens the page (view) with the same name in Views/Home
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Policy()
        {
            return View();
        }

        // error page (comes with the template, do not remove)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}