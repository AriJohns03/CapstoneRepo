using Capstone1.Interfaces;
using Capstone1.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Console.WriteLine(id);
            Console.WriteLine("hitting edit code-------");
            if (id == null)
            {
                ViewData["Error"] = "Event was not provided";
                return View();
            }
            else
            {
                Event? ev = dal.GetEvent(id);
                if (ev == null)
                {
                    ViewData["Error"] = "The event id does not exist";
                }
                return View(ev);
            }
        }

        [HttpPost]
        public IActionResult Edit(Event e)
        {
            dal.UpdateEvent(e);
            TempData["Message"] = "Event updated";
            return RedirectToAction("EventCollection", "Event");
        }


        public IActionResult Delete(int? id)
        {
            Event e = dal.GetEvent(id);
            if (dal.RemoveEvent(id))
            {
                TempData["Message"] = "Event " + e.Name + " Deleted";
            }
            else
            {
                TempData["Message"] = "Event Unsuccessfully Deleted";
            }
            return RedirectToAction("EventCollection", "Event");
        }

        [HttpPost]
        public IActionResult Search(string inSearch)
        {
            if (string.IsNullOrEmpty(inSearch))
            {
                return RedirectToAction("EventCollection", "Event");
            }
            return View("EventCollection", dal.SearchEvents(inSearch));
        }

        public IActionResult ReturnEvent(int id)
        {
            dal.ReturnEvent(id);
            return Redirect("EventsCollection");
        }
    }
}
