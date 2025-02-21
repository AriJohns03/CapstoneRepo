using Capstone1.Interfaces;
using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Controllers
{
    public class EventController : Controller
    {
        private IDataAccessLayer dal;

        public EventController(IDataAccessLayer indb) {
            dal = indb;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EventCollection()
        {
            return View(dal.GetEvents());
        }

        [HttpPost]
        public IActionResult EventCollection(IEnumerable<Event> events)
        {
            return View(dal.GetEvents());
        }

        [HttpGet]
        public IActionResult Add()
        {
            Console.WriteLine("Hitting EventController Code Segment");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Event e) {

            if (ModelState.IsValid)
            {
                dal.AddEvent(e);
                TempData["Message"] = e.Name + " event saved!";
                return RedirectToPage("/Index");
            }
            else
            {
                return View();
            }
        }

    }
}
