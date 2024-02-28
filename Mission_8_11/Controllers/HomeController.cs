using Microsoft.AspNetCore.Mvc;
using Mission_8_11.Models;
using System.Diagnostics;

namespace Mission_8_11.Controllers
{
    public class HomeController : Controller
    {
        private IStatsRepository _repo;

        public HomeController(IStatsRepository temp) 
        { 
            _repo = temp;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Stat());
        }
        [HttpPost]
        public IActionResult Index(Stat s) 
        {
            if (ModelState.IsValid) 
            {
                _repo.AddStat(s);
            
            }

            return View(new Stat());
        
        }



    }
}
