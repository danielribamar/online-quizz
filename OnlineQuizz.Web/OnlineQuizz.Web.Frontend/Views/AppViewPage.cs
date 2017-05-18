using System.Security.Claims;
using System.Web.Mvc;

namespace OnlineQuizz.Web.Frontend.Views
{
    using Models;
    
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}