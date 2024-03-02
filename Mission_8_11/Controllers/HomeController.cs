using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mission_8_11.Models;

namespace Mission_8_11.Controllers
{
    public class HomeController : Controller
    {
        // Make an instance of the repo
        private IStatsRepository _repo;

        // Make the constructor so we can use repository pattern
        public HomeController(IStatsRepository temp) 
        {
            _repo = temp;
        }

        // Get action for index (which will be its only action
        [HttpGet]
        public IActionResult Index()
        {
            // use the GetStatsWithCategory method and return it with the view for displaying the matrix
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
            // If the ModelState is Valid add it to the database
            if (ModelState.IsValid) 
            {
                // call the AddStat method from the repository
                _repo.AddStat(s);

                return View("Confirmation");
            }
            // If it isn't valid, stay on this screen and make them edit it til it is valid
            else
            {
                // Make a view bag for getting the categories
                ViewBag.Categories = _repo.Categories;

                return View(s);
            }        
        }

        // Get action for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // grab the record from the repo based on the id passed
            var recordToEdit = _repo.Stats.Single(x => x.TaskId == id);

            // Make a view bag for getting the categories
            ViewBag.Categories = _repo.Categories;

            return View("NewTask", recordToEdit);
        }

        // Post action for Edit
        [HttpPost]
        public IActionResult Edit(Stat updatedTask)
        {
            // If what they edited is valid
            if (ModelState.IsValid)
            {
                // Call the EditStat method to update the record
                _repo.EditStat(updatedTask);
                
                // go to the Index action to see the matrix
                return RedirectToAction("Index");
            }
            // If they took out a required field
            else
            {
                // make the viewbag again 
                ViewBag.Categories = _repo.Categories;

                // make them reupdate the task
                return View("NewTask", updatedTask);
            } 
        }

        // Get Action for Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // grab the record to delete based on the id passed
            var recordToDelete = _repo.Stats.Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        // Post action for Delete
        [HttpPost]
        public IActionResult Delete(Stat deletedTask)
        {
            // call the DeleteStat method to delete the task
            _repo.DeleteStat(deletedTask);

            // redirect to index to see the matrix
            return RedirectToAction("Index");
        }
    }   
}
