using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CompanyPage(Company company)
        {
            if (company == null)
                company = new Company();
            return View(company);
        }
        public IActionResult Edit(long ID)
        {
            Company company = new Company();
            CompanyRepository.CompanRep.GetCompanyByID(ID);
            return View("CompanyPage", company);
        }

        public IActionResult Update(Company company)
        {
            CompanyRepository.CompanRep.Update(company);
            company = new Company();
            return View("CompanyPage", company);
        }
    
    }
}
