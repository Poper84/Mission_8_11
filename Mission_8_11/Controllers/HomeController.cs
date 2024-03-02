using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mission_8_11.Models;

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
            var tasks = _repo.GetStatsWithCategory().ToList();

            return View(tasks);
        }

        // Get action for the NewTask View
        [HttpGet]
        public IActionResult NewTask()
        {
            // Make a view bag for getting the categories
            ViewBag.Categories = _repo.Categories;

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
            var recordToEdit = _repo.Stats.Single(x => x.TaskId == id);

            // Make a view bag for getting the categories
            ViewBag.Categories = _repo.Categories;

            return View("NewTask", recordToEdit);
        }

        // Post action for Edit
        [HttpPost]
        public IActionResult Edit(Stat updatedTask)
        {
            if (ModelState.IsValid)
            {
                _repo.EditStat(updatedTask);
                
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _repo.Categories;

                return View("NewTask", updatedTask);
            } 
        }

        // Get Action for Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Stats.Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        // Post action for Delete
        [HttpPost]
        public IActionResult Delete(Stat deletedTask)
        {
            _repo.DeleteStat(deletedTask);

            return RedirectToAction("Index");
        }
    }   
}
