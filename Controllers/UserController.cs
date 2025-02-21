using Capstone1.Data;
using Capstone1.Interfaces;
using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Controllers
{

    public class UserController : Controller
    {
        private UDataAccessLayer dal;

        public UserController(UDataAccessLayer indb)
        {
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
        public IActionResult Add(UserModel u)
        {
            if (ModelState.IsValid)
            {
                dal.AddUser(u);

                TempData["Message"] = u.FirstName + " event saved!";
                return RedirectToPage("/Index");
            }
            else
            {
                return View();
            }
        }

    }
}

