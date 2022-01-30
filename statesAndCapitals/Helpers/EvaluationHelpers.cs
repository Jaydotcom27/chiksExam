using statesAndCapitals.Data;

namespace statesAndCapitals.Helpers
{
    public class EvaluationHelpers
    {
        public bool EvaluateEntry(StatesAndCapitalsContext context, string state, string capital)
        {
            capital = capital.Replace(" ", string.Empty).ToLower();
            if (string.IsNullOrEmpty(state) || string.IsNullOrEmpty(capital)) return false; 
            if (capital == context.States.ToList().Where(x => x.State1 == state).Select(x => x.Capital).FirstOrDefault().Replace(" ", string.Empty).ToLower())
            {
                return true;
            }
            return false;
        }

        public static double CalculateGrade(double numberCorrect, double totalQuestion)
        {
            return (numberCorrect/totalQuestion)*100;
        }
    }
}
