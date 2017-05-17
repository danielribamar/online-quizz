using System.Web.Mvc;

namespace OnlineQuizz.Web.Frontend.Controllers
{
    public class AuthController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}