using HRManagement.Data.Entities;
using HRManagement.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuratS_Blog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        UploadFiles uploadImages;
        public SettingsController(IWebHostEnvironment webHostEnvironment)
        {
            uploadImages = new UploadFiles(webHostEnvironment);
            
        }
        public IActionResult Index(Personel? personel)
        {
            personel = PersonelRepository.PersonelsRepository.GetPersonelByID(1);
            return View(personel);
        }

        public IActionResult UserEdit(long ID)
        {

            return View(PersonelRepository.PersonelsRepository.GetPersonelByID(ID));
        }

        public IActionResult CompanyEdit(long ID)
        {

            return View(CompanyRepository.CompanRep.GetCompanyByID(ID));
        }

        public IActionResult UserUpdate(Personel personel,IFormFile? profilPicUrl)
        {
            Personel updatedPersonel = PersonelRepository.PersonelsRepository.GetPersonelByID(1);
            updatedPersonel.FirstName = personel.FirstName;
            updatedPersonel.LastName = personel.LastName;
            updatedPersonel.ProfilPicUrl = uploadImages.UploadedImage(profilPicUrl);
            PersonelRepository.PersonelsRepository.Update(updatedPersonel);

            //geçiçi olarak yönlendirme işlemi için eklendi Buraya login olan kullanıcının bilgileri gelicek.
            return RedirectToAction("Index",PersonelRepository.PersonelsRepository.GetPersonelByID(personel.ID));
        }

        public IActionResult CompanyUpdate(Company company, IFormFile? logo)
        {
            company.Logo = uploadImages.UploadedImage(logo);
            CompanyRepository.CompanRep.Update(company);

            //geçiçi olarak yönlendirme işlemi için eklendi Buraya login olan kullanıcının bilgileri gelicek.
            return RedirectToAction("Index", PersonelRepository.PersonelsRepository.GetPersonelByID(1));
        }
    }
}
