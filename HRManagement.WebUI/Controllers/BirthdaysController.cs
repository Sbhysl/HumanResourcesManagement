using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Controllers
{
    public class BirthdaysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
