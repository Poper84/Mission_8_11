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
            var Tasks = _repo.Stats.ToList();

            return View(Tasks);
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

            return View("Confirmation");
        }

        // Get action for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var RecordToEdit = _repo.Stats.Where(x => x.TaskId == id);

            return View("NewTask", RecordToEdit);
        }

        // Post action for Edit
        [HttpPost]
        public IActionResult Edit(Stat s)
        {
            //_repo.EditStat(s);

            return RedirectToAction("Index");
        }

        // Get Action for Delete
        public IActionResult Delete(int id)
        {
            var RecordToDelete = _repo.Stats.Where(x => x.TaskId == id);

            return View(RecordToDelete);
        }

        // Post action for Delete
        public IActionResult Delete(Stat s)
        {
            // _repo.DeleteStat(s);

            return RedirectToAction("Index");
        }
    }   
}
