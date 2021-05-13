using System.Collections.Generic;
using System.Threading.Tasks;
using HRManagement.Data;
using HRManagement.Data.Entities;
using HRManagement.Data.Repositories;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.WebUI.Views.Shared.Components.UpcomingPayments
{
    public class UpcomingPaymentsViewComponent:ViewComponent
    {
      
        public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Personel> personels;
            UpcomingPaymentRep.PaymentRep.GetUpComingPayments(out personels);
            return Task.FromResult<IViewComponentResult>(View(personels));
        }

    }
}
