using DavomatProject.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.Domain;
using System.Net.Http;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpPost]
        [Route("save")]
        public string UploadImage([FromForm]IFormFile image)
        {
            return _imageService.SaveImage(image);
        }
    }
}
