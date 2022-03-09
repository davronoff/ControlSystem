using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DavomatProject.Api.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteImage(string name)
        {
            throw new System.NotImplementedException();
        }

        public string SaveImage(IFormFile image)
        {
            string uniqueName = string.Empty;
            if (image.FileName != null)
            {
                string uplodFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueName = Guid.NewGuid().ToString()+"_"+image.FileName;
                string filePath = Path.Combine(uplodFolder, uniqueName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                image.CopyTo(fileStream);
                fileStream.Close();
            }

            return "https://ilyosbek.uz/rtm/images/" + uniqueName;
        }
    }
}
