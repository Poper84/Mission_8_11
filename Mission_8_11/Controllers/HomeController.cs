using Microsoft.AspNetCore.Mvc;
using Mission_8_11.Models;
using System.Diagnostics;

namespace Mission_8_11.Controllers
{
    public class HomeController : Controller
    {
        // Make an instance of the context
        private IStatsRepository _repo;

        // Make the constructor so we can use repository pattern
        public HomeController(IStatsRepository temp) 
        {
            _repo = temp;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Get action for the NewTask View
        [HttpGet]
        public IActionResult NewTask()
        {
            // Make a view bag for getting the categories
            ViewBag.Categories = _repo.Categories.ToList();

            // return the view with a new Stat model so the TaskId defaults to 0 for a new entry
            return View(new Stat());
        }

        // Post action for the NewTask View
        [HttpPost]
        public IActionResult NewTask(Stat s)
        {
            if (ModelState.IsValid) 
            {
                _repo.AddStat(s);
            }

            return View(new Stat());
        }
    }
}
