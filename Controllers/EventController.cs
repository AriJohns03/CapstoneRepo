using Capstone1.Interfaces;
using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Controllers
{
    public class EventController : Controller
    {
        IDataAccessLayer dal;

        public EventController(IDataAccessLayer indb) {
            dal = indb;
        }

        public IActionResult Index()
        {
            return View();
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
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}
