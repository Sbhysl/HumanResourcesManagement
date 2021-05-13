using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace MuratS_Blog.Services
{
    public class UploadFiles
    {

        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadFiles(IWebHostEnvironment webHostEnvironment)
        {

            this._webHostEnvironment = webHostEnvironment;
        }

        public string UploadedImage(IFormFile image)
        {
            string uniqueFileName = "user.png";

            if (image != null)
            {

                string imgtext = Path.GetExtension(image.FileName);
                if (imgtext == ".jpg" || imgtext == ".gif" || imgtext == ".png" || imgtext == ".PNG" || imgtext == ".JPG" || imgtext == ".Jpg" || imgtext == ".jpeg")
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }
                }
            }
            return uniqueFileName;
        }
    }
}
