using System.Configuration;
using System.Web;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OnlineQuizz.Web.Frontend
{
    using Core.Helpers;
    using Core.Models;
    using OnlineQuizz.Web.Core.Business;

    public class FacebookOAuth : IHttpHandler
    {
        private string appId = ConfigurationManager.AppSettings["Facebook.AppId"];
        private string appSecret = ConfigurationManager.AppSettings["Facebook.AppSecret"];

        private string loginUrl = "https://www.facebook.com/v2.9/dialog/oauth?client_id={0}&redirect_uri={1}&scope=email,public_profile";
        private string exchangeCodeUrl = "https://graph.facebook.com/v2.9/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}";
        private string getUserProfileUrl = "https://graph.facebook.com/me?fields=first_name,last_name,email&access_token={0}";

        public void ProcessRequest(HttpContext context)
        {
            var redirectUrl = $"{UrlHelper.GetBaseUrl()}FacebookOAuth.ashx";

            if (string.IsNullOrWhiteSpace(context.Request["code"]))
            {

                context.Response.Redirect(string.Format(loginUrl, appId, redirectUrl));
            }
            else
            {
                var code = context.Request["code"];

                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var baseAddress = new Uri(string.Format(exchangeCodeUrl, appId, redirectUrl, appSecret, code));
                var response = client.GetAsync(baseAddress).Result;

                if (response.IsSuccessStatusCode)
                {
                    var access_token_data = response.Content.ReadAsAsync<dynamic>();
                    var access_token = access_token_data.Result.access_token;

                    response = client.GetAsync(string.Format(getUserProfileUrl, access_token)).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var profile_data = response.Content.ReadAsAsync<UserModel>().Result;
                        profile_data.AccessToken = access_token;
                        UserManager.RegisterUser(profile_data);


                    }
                    else
                    {
                        //TODO: Handle error
                    }
                }
                else
                {
                    //TODO: Handle error
                }
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}