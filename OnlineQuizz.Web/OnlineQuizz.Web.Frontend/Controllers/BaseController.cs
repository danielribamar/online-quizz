using System.Web.Mvc;
using System.Security.Claims;

namespace OnlineQuizz.Web.Frontend.Controllers
{
    using Models;
    
    public abstract class BaseController : Controller
    {
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }
    }
}