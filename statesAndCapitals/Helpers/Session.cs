using statesAndCapitals.Models;

namespace statesAndCapitals.Helpers
{
    public static class Session
    {
        private static User _user = new User();
        private static bool isLoggedIn = false;

        public static void LogIn(User user)
        {
            isLoggedIn = true;
            _user = user;
        }

        public static void LogOut()
        {
            _user = null;
            isLoggedIn = false;
        }

        public static bool IsLogged()
        {
            return isLoggedIn;  
        }

        public static int GetUserId()
        {
            return _user.UserId;
        }

    }
}
