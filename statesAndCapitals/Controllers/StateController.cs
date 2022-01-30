using Microsoft.AspNetCore.Mvc;
using statesAndCapitals.Data;
using statesAndCapitals.Models;

namespace statesAndCapitals.Controllers
{
    public class StateController : Controller
    {
        private readonly StatesAndCapitalsContext _context;

        public StateController(StatesAndCapitalsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<State> states = _context.States.ToList();
            return View(states);
        }

        public IActionResult Details(int Id)
        {
            State state = _context.States.Where(p => p.StateId == Id).FirstOrDefault();
            return View(state);
        }
    }
}
