namespace OnlineQuizz.Web.Core.Business
{
    using DataAccess;
    using Models;

    public static class UserManager
    {
        public static void RegisterUser(UserModel user)
        {
            if (UserRepository.GetUser(user.FacebookId) == null)
            {
                UserRepository.RegisterUser(user);
            }
            else
            {

            }
        }
    }
}
