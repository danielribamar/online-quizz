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

        internal static void Register(UserModel user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var q_register = "insert into users (FacebookId,Email,AccessToken,FirstName,LastName,RegisterDate) values(@FacebookId,@Email,@AccessToken,@FirstName,@LastName,@RegisterDate)";

                connection.Execute(q_register,
                    new { FacebookId = user.FacebookId, Email = user.Email, AccessToken = user.AccessToken, FirstName = user.FirstName, LastName = user.LastName, RegisterDate = DateTime.Now });
            }
        }

        internal static UserModel Get(string facebookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var q_get = "select * from users where FacebookId like @FacebookId";

                return connection.Query<UserModel>(q_get, new { FacebookId = facebookId }).FirstOrDefault();
            }
        }
        internal static void Update(UserModel user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var q_update = "update users set FirstName = @FirstName, LastName = @LastName, Email = @Email, AccessToken = @AccessToken where FacebookId like @FacebookId";

                connection.Execute(q_update, user);
            }
        }
    }
}
