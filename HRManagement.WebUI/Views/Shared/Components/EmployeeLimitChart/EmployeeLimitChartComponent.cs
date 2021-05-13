using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Views.Shared.Components.Chart
{
    [ViewComponent(Name = "EmployeeLimitChart")]
    public class EmployeeLimitChartComponent : ViewComponent
    {
        //PersonelRepository personelRep;

        //public GetEmployeeListViewComponent()
        //{
        //    personelRep = new PersonelRepository();
        //}

        public Task<IViewComponentResult> InvokeAsync()
        {
            
            return Task.FromResult<IViewComponentResult>(View(PersonelRepository.PersonelsRepository.GetDepartmanInfo()));
        }
    }
}
