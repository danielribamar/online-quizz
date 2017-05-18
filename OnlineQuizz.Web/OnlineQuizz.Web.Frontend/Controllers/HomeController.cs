using System.Web.Mvc;

namespace OnlineQuizz.Web.Frontend.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}