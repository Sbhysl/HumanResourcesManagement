using System.Collections.Generic;
using System.Threading.Tasks;
using HRManagement.Data;
using HRManagement.Data.Entities;
using HRManagement.Data.Repositories;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.WebUI.Views.Shared.Components.OffDayList
{
    public class OffDayListViewComponent:ViewComponent
    {
       public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<OffDay> offDays;
            OffDayRepository.OffDayRep.GetOffDays(out offDays);
            return Task.FromResult<IViewComponentResult>(View(offDays));
        }
    }
}
