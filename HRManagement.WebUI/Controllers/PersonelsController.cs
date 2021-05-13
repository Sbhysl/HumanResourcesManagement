using HRManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Controllers
{
    public class PersonelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpcomingPayments()
        {
            return View();
        }
        public IActionResult Birthdays()
        {
            return View();
        }
   
    }
}
