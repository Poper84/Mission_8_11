using Microsoft.AspNetCore.Mvc;
using Mission_8_11.Models;
using System.Diagnostics;

namespace Mission_8_11.Controllers
{
    public class HomeController : Controller
    {
        // Make an instance of the context
        private ICoolDataRepository _repo;

        // Make the constructor so we can use repository pattern
        public HomeController(ICoolDataRepository temp) 
        {
            _repo = temp;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Stat());
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
