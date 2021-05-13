using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Views.Shared.Components.
    
    
    Edit
{
    public class CompanyEditViewComponent:ViewComponent
    {
    
        public CompanyEditViewComponent()
        {

        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Company> companies;
            CompanyRepository.CompanRep.GetOffCompanies(out companies);
            return Task.FromResult<IViewComponentResult>(View(companies));
        }
    
    }
}
