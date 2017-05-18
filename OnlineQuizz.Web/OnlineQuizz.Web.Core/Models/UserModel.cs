using Newtonsoft.Json;

namespace OnlineQuizz.Web.Core.Models
{

    public class UserModel
    {
        public int Id { get; set; }

        [JsonProperty("id")]
        public string FacebookId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
