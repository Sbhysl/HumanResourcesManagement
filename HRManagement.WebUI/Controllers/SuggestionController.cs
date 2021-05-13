using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Controllers
{
    public class SuggestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SuggestionPage(Suggestion? suggestion)
        {
            if (suggestion==null)
            {
                suggestion = new Suggestion();
            }
            return View(suggestion);
        }
        public IActionResult Edit(long ID)
        {
            Suggestion suggestion = new Suggestion();
            suggestion = SuggestionRepository.SuggestionRep.GetSuggestionByID(ID);
            return View("SuggestionPage", suggestion);
        }

        public IActionResult Update(Suggestion suggestion)
        {
            SuggestionRepository.SuggestionRep.Update(suggestion);
            suggestion = new Suggestion();
            return View("SuggestionPage", suggestion);
        }

        public IActionResult Delete(long ID,Suggestion? suggestion)
        {
            if (suggestion==null)
            {
                suggestion = new Suggestion();
            }
            SuggestionRepository.SuggestionRep.Delete(ID);
            return View("SuggestionPage", suggestion);
        }

        public IActionResult AddSuggestion(Suggestion suggestion)
        {
            suggestion.CompanyID = 1;
            suggestion.ModifiedDate = DateTime.Now;
            suggestion.CreatedDate = DateTime.Now;
            suggestion.IsActive = true;

            if (suggestion!=null)
            {
                SuggestionRepository.SuggestionRep.Add(suggestion);

            }
            else
            {
                suggestion = new Suggestion();
            }
            return View("SuggestionPage", suggestion);
        }




    }
}
