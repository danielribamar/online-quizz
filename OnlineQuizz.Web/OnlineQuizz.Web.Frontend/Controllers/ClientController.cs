using System.Web.Mvc;

namespace OnlineQuizz.Web.Frontend.Controllers
{
    public class ClientController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}