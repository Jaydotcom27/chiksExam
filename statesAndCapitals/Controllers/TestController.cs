using Microsoft.AspNetCore.Mvc;
using statesAndCapitals.Data;
using statesAndCapitals.Helpers;
using statesAndCapitals.Models;

namespace statesAndCapitals.Controllers
{
    public class TestController : Controller
    {
        private readonly StatesAndCapitalsContext _context;
        public TestController(StatesAndCapitalsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Test()
        {

            return View(_context.States.ToList().Shuffle().Take(10));
        }

        [HttpPost]
        public ActionResult Evaluate(IFormCollection collection)
        {
            int counter = 0;
            foreach (var item in collection)
            {
                EvaluationHelpers evaluation = new EvaluationHelpers();
                if (evaluation.EvaluateEntry(_context, item.Key, (string)item.Value.FirstOrDefault()))
                {
                    counter++;
                }
            }
            SaveTestResult(counter);
            return RedirectToAction("Result");
        }

        [HttpGet]
        public ActionResult Result()
        {
            if (!Session.IsLogged())
            {
                return RedirectToAction("Login", "Account");
            }
            var testResults = _context.TestResults.ToList().LastOrDefault();
            testResults.User = _context.Users.ToList().Where(x => x.UserId == Session.GetUserId()).First();
            testResults.User.TestResults = testResults.User.TestResults.Reverse().Take(10).ToList();
            return View(testResults);
        }

        [HttpPost]
        public ActionResult LogOut(Account acc)
        {
            Session.LogOut();
            return RedirectToAction("Login", "Account");
        }

        public void SaveTestResult(int counter)
        {
            var testResult = new TestResult();
            testResult.UserId = Session.GetUserId();
            testResult.TestDateTime = DateTime.Now;
            testResult.TotalQuestions = 10;
            testResult.NumberCorrect = counter;
            _context.TestResults.Add(testResult);
            _context.SaveChanges();
        }

    }
}
