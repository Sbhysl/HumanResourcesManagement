using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Views.Shared.Components.PublicHolidayEditList
{
    [ViewComponent(Name = "PublicHolidayEditList")]
    public class PublicHolidayEditListComponent : ViewComponent
    {
        public PublicHolidayEditListComponent()
        {
        }

        //veri okumaları asynrn yapı olduğu için componentler aşağıdaki gibi olmalı . asynrn olmadığındada IViewComponentResult şeklinde olmalı IActionResult değil

        public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<PublicHolidays> publicHolidays;

            //Repository kullanımı !!dikkat contructer boş / globalde obje yok
            //PublicHolidaysRepository.HolidaysRepository .Add() .GetPublicHolidays() .Remove() gibi gibi
            PublicHolidaysRepository.HolidaysRepository.GetPublicHolidays(out publicHolidays);

            //asyrn olarak dönüş
            return Task.FromResult<IViewComponentResult>(View(publicHolidays));
        }

    }
}
