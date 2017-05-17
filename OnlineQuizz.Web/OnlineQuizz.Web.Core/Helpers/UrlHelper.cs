using System.Web;

namespace OnlineQuizz.Web.Core.Helpers
{
    public static class UrlHelper
    {
        public static string GetBaseUrl()
        {
            return string.Concat(
                HttpContext.Current.Request.Url.Scheme + "://",
                HttpContext.Current.Request.Url.Authority,
                HttpContext.Current.Request.ApplicationPath.TrimEnd('/'),
                "/");
        }
    }
}
