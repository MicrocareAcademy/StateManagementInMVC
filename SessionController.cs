using Microsoft.AspNetCore.Mvc;

namespace StateManagement
{
    public class SessionController : Controller
    {
        private readonly string _userEmailKey = "UserEmail";

        public IActionResult Login()
        {
            var userEmail = HttpContext.Session.GetString(_userEmailKey);

            if(!string.IsNullOrEmpty(userEmail))
            {
                // still user data inside session
                return RedirectToAction("Welcome", "Session");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            var email = form["Email"];
            var password = form["Password"];


            HttpContext.Session.SetString(_userEmailKey, email);

            return RedirectToAction("Welcome", "Session");
        }

        public IActionResult Welcome()
        {
            var userEmail = HttpContext.Session.GetString(_userEmailKey);

            return View("Welcome",userEmail);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(_userEmailKey);

            //HttpContext.Session.Clear();

            return RedirectToAction("Login", "Session");
        }
    }
}
