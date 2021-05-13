using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Controllers
{
    public class PublicHolidaysManagementController : Controller
    {
        public IActionResult Index(PublicHolidays? publicHolidays)
        {
            //input valuelerine atama yapabilmeniz için indexte boş bir obje yollanmalı
            if(publicHolidays==null)
            publicHolidays = new PublicHolidays();

            //Mock(sahte) veri kullanımı buradaki publicholidays i satır satır elle doldursaydınız ve bunu yollasaydınız index teki valueleri atanmış yerler dolu gelirdi.Repo veya API olmadığında buradan başlamak isterseniz bu şekilde sahte veri ile çalışabilirsiniz.
            return View(publicHolidays);
        }

        public IActionResult Edit(long ID)
        {
            PublicHolidays publicHolidays = new PublicHolidays();
            publicHolidays = PublicHolidaysRepository.HolidaysRepository.GetPublicHolidaysByID(ID);


            return View("Index", publicHolidays);
        }
        public IActionResult Update(PublicHolidays publicHolidays)
        {

            PublicHolidaysRepository.HolidaysRepository.Update(publicHolidays);

            publicHolidays = new PublicHolidays();
            return View("Index",publicHolidays);
        }

        public IActionResult Delete(long ID, PublicHolidays? publicHolidays)
        {
            if (publicHolidays == null)
                publicHolidays = new PublicHolidays();

            PublicHolidaysRepository.HolidaysRepository.Delete(ID);

            return View("Index", publicHolidays);
        }

        public IActionResult AddPublicHoliday(PublicHolidays publicHolidays)
        {
            //Ekleme işlemi yaparken formdan gelen veri obje şeklinde burada dikkat bazı gerekli özellikleri eklemediğinizde mesela offdays yok
            // burada mock veri / sahte veri demek aşağıdagördüğünüz gibi alınabiliyor. 
            
            publicHolidays.ModifiedDate = DateTime.Now;
            publicHolidays.CreatedDate = DateTime.Now;
            publicHolidays.IsActive = true;



            if (publicHolidays != null)
            {
                PublicHolidaysRepository.HolidaysRepository.Add(publicHolidays);
            }
            else
            {
                publicHolidays = new PublicHolidays();
            }
                
            return View("Index", publicHolidays);
        }



        
    }
}
