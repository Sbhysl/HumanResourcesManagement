using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Views.Shared.Components.UserSettings
{
    [ViewComponent(Name = "UserSettings")]
    public class UserSettingsComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(Personel personel)
        {
            return Task.FromResult<IViewComponentResult>(View(PersonelRepository.PersonelsRepository.GetPersonelByID(personel.ID)));
        }
    }
}
