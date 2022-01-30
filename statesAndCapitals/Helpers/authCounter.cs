namespace statesAndCapitals.Helpers
{
    static public class authCounter
    {
        private static int counter;

        public static int checkLoginAttemps()
        {
            return counter;
        }

        public static void addLoginAttempt()
        {
            counter++;  
        }
    }
}
