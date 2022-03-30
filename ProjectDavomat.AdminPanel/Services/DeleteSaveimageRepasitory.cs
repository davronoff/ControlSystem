using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectDavomat.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Services
{
    public class DeleteSaveimageRepasitory : IDeleteSaveimageInterface
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteSaveimageRepasitory(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteImage(string fileName)
        {
            try
            {
                fileName = fileName.Split(new string[] { "https://ilyosbek.uz/rtm/images/" }, StringSplitOptions.None)[1];

                if (fileName is not null)
                {
                    string uplodFolder = Path.Combine(@"C:\inetpub\wwwroot\RTM_API\wwwroot\", "images");
                    string filePath = Path.Combine(uplodFolder, fileName);
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> SaveImageAsync(IFormFile formFile)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44336/api/image/");
            MultipartFormDataContent form = new MultipartFormDataContent();
            HttpContent content = new StringContent("file");
            form.Add(content, "file");
            var stream = formFile.OpenReadStream();
            content = new StreamContent(stream);
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "file",
                FileName = formFile.FileName
            };
            form.Add(content);

            var response = await client.PostAsync("save", form);
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
