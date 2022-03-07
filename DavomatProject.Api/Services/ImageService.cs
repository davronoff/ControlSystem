using Microsoft.AspNetCore.Hosting;
using ProjectDavomat.Domain;
using System;
using System.IO;

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

        public string SaveImage(ImageModel image)
        {
            string uniqueName = string.Empty;
            using (var memory = new MemoryStream(image.ImageFile))
            {
                if (image.ImageFile != null)
                {
                    string uplodFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    uniqueName = Guid.NewGuid().ToString() + "_" + image.Name;
                    string filePath = Path.Combine(uplodFolder, uniqueName);
                    FileStream fileStream = new FileStream(filePath, FileMode.Create);
                    memory.CopyTo(fileStream);
                    fileStream.Close();
                }
            }

            return "https://ilyosbek.uz/rtm/images/" + uniqueName;
        }
    }
}
