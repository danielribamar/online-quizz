using System.Security.Claims;

namespace OnlineQuizz.Web.Frontend.Models
{
    public class AppUser : ClaimsPrincipal
    {
        public AppUser(ClaimsPrincipal principal)
       : base(principal)
        {
        }

        public string Name
        {
            get
            {
                return FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string Email
        {
            get
            {
                return FindFirst(ClaimTypes.Email).Value;
            }
        }

        public string FacebookId
        {
            get
            {
                return FindFirst("FacebookId").Value;
            }
        }

        public string ProfilePictureUrl
        {
            get
            {
                return $"http://graph.facebook.com/{FindFirst("FacebookId").Value}/picture?type=large";
            }
        }
    }
}