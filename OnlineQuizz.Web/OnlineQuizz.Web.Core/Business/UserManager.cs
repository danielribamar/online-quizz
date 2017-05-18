namespace OnlineQuizz.Web.Core.Business
{
    using DataAccess;
    using Models;

    public static class UserManager
    {
        public static void RegisterUser(UserModel user)
        {
            if (UserRepository.Get(user.FacebookId) == null)
            {
                UserRepository.Register(user);
            }
            else
            {
                UserRepository.Update(user);
            }
        }
    }
}
