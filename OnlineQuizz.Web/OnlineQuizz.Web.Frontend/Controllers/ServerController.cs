using System.Web.Mvc;

namespace OnlineQuizz.Web.Frontend.Controllers
{
    public class ServerController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}