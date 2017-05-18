using System.Web;
using System.Web.Mvc;

namespace OnlineQuizz.Web.Frontend.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }
    }
}