using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManagement.Data;
using HRManagement.Data.Entities;
using HRManagement.Data.Repositories;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.WebUI.Views.Shared.Components.GetEmployeeList
{
    //[ViewComponent(Name = "PersonelList")]
    public class GetEmployeeListViewComponent:ViewComponent
    {
        //PersonelRepository personelRep;

        //public GetEmployeeListViewComponent()
        //{
        //    personelRep = new PersonelRepository();
        //}

        public Task<IViewComponentResult>InvokeAsync()
        {

            IEnumerable<Personel> personels;
            PersonelRepository.PersonelsRepository.GetPersonels1(out personels);
            return Task.FromResult<IViewComponentResult>(View(personels));
        }
    }
}
