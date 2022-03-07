using DavomatProject.Api.Services;
using Microsoft.AspNetCore.Mvc;
using ProjectDavomat.Domain;

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
        public string UploadImage(ImageModel image)
        {
            string res = _imageService.SaveImage(image);

            return res;
        }
    }
}
