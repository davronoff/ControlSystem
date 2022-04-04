using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        [Route("save")] 
        public string UploadImage(IFormFile file)
        {
            string uniqueName = string.Empty;
            if (file != null)
            {
                string uplodFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uplodFolder, uniqueName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
                fileStream.Close();
            }

            return "https://ilyosbek.uz/rtm/images/"+uniqueName;
        }

        [HttpDelete]
        [Route("delete/{fileName}")]
        public void DeleteImage(string fileName)
        {
            if (fileName is not null)
            {
                string uplodFolder = Path.Combine(_environment.WebRootPath, "Images");
                string filePath = Path.Combine(uplodFolder, fileName);
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
        }
    }
}
