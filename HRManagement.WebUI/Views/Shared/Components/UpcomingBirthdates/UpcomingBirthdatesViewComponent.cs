using System.Collections.Generic;
using System.Threading.Tasks;
using HRManagement.Data;
using HRManagement.Data.Entities;
using HRManagement.Data.Repositories;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.WebUI.Views.Shared.Components.UpcomingBirthdates
{
    public class UpcomingBirthdatesViewComponent : ViewComponent
    {


        public Task<IViewComponentResult> InvokeAsync()
        {
       

            IEnumerable<Personel> personels;
            UpcomingBirthdaysRepository.BirthdaysRepository.GetUpComingBirthdays2(out personels);

            return Task.FromResult<IViewComponentResult>(View(personels));
        }



    }
}
