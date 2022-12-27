using Microsoft.AspNetCore.Mvc;

namespace StateManagement
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            // Once we store the cookie , then browser will send cookie on every request
            // and we can access the cookie as key valaue pair Request.Cookies[key]

            //read cookie from Request object  
            string userName = Request.Cookies["UserCookie"]; // accesing cookie

            return View("Index",userName);
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            // here UserName is the Input Element Name
            // form["UserName"] , will give us the input element value 
            // we are storing the value insdie the variable userName
            
            string userName = form["UserName"].ToString();


            //set the key value in Cookie              
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1);

            //Current time = 27-12-2022 07:10 AM
            // Expires time = 27-12-2022 07:20 AM

            //browser will store cookie and will expires automatically after one min
            Response.Cookies.Append("UserCookie",userName,option);

            return RedirectToAction("Index","Cookie");
        }

        public IActionResult ForgetCookie()
        {
            Response.Cookies.Delete("UserCookie");

            return RedirectToAction("Index", "Cookie");
        }
    }
}
