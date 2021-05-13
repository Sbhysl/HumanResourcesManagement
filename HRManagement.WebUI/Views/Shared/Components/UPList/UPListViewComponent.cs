using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Views.Shared.Components.UPList
{
    public class UPListViewComponent:ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Personel> personels;
            UpcomingPaymentRep.PaymentRep.GetUpComingPayments(out personels);
            return Task.FromResult<IViewComponentResult>(View(personels));
        }
    }
}
