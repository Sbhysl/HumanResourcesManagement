using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Views.Shared.Components.SuggestionEditList
{
    public class SuggestionEditListViewComponent:ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Suggestion> suggestions;
            SuggestionRepository.SuggestionRep.GetSuggestions(out suggestions);
            return Task.FromResult<IViewComponentResult>(View(suggestions));
        }
    }
}
