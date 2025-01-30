using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;

namespace Capstone1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
    public IActionResult SubmitTime(string timeInput)
    {
        if (TimeSpan.TryParse(timeInput, out TimeSpan time))
        {
            ViewBag.Message = $"Time received: {time}";
        }
        else
        {
            ViewBag.Message = "Invalid time format.";
        }

        return Redirect("SubmitTime");
    }
}
