using System;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace OnlineQuizz.Web.Core.DataAccess
{
    using Models;
    using System.Linq;

    internal static class UserRepository
    {
        private readonly static string _connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        internal static void RegisterUser(UserModel user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var q_register = "insert into users (FacebookId,AccessToken,FirstName,LastName,RegisterDate) values(@FacebookId,@AccessToken,@FirstName,@LastName,@RegisterDate)";

                connection.Execute(q_register,
                    new { FacebookId = user.FacebookId, AccessToken = user.AccessToken, FirstName = user.FirstName, LastName = user.LastName, RegisterDate = DateTime.Now });
            }
        }

        internal static UserModel GetUser(string facebookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var q_getUser = "select * from users where FacebookId like @FacebookId";

                return connection.Query<UserModel>(q_getUser, new { FacebookId = facebookId }).FirstOrDefault();
            }
        }
    }
}
