using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Controllers
{
    public class OffDayController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DayOffPage(OffDay? offDay)
        {
            if (offDay == null)
                offDay = new OffDay();
            return View(offDay);
        }

        public IActionResult Edit(long ID)
        {
            OffDay offDay = new OffDay();
            offDay = OffDayRepository.OffDayRep.GetOffDaysByID(ID);


            return View("DayOffPage", offDay);
        }
        public IActionResult Update(OffDay offDay)
        {

            OffDayRepository.OffDayRep.Update(offDay);

            offDay = new OffDay();
            return View("DayOffPage", offDay);
        }

        public IActionResult Delete(long ID, OffDay? offDay)
        {
            if (offDay == null)
                offDay = new OffDay();

            OffDayRepository.OffDayRep.Delete(ID);

            return View("DayOffPage", offDay);
        }
        public IActionResult AddOffDay(OffDay? offDays)
        {
            offDays.ModifiedDate = DateTime.Now;
            offDays.CreatedDate = DateTime.Now;
            offDays.IsActive = true;



            if (offDays != null)
            {
                OffDayRepository.OffDayRep.Add(offDays);
            }
            else
            {
                offDays = new OffDay();
            }

            return View("DayOffPage", offDays);
        }

    }
}
