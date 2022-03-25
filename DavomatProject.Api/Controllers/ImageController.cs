using Amazon.S3;
using Amazon.S3.Model;
using DavomatProject.Api.Services;
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
        private readonly IAmazonS3 _amazonS3;

        public ImageController(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }

        [HttpPost]
        [Route("save")] 
        public async Task<string> UploadImage(IFormFile file)
        {
            string uniqueName = Guid.NewGuid().ToString() + file.FileName;
            var put = new PutObjectRequest()
            {
                BucketName = "rtm-images",
                Key = uniqueName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            var result = await _amazonS3.PutObjectAsync(put);

            return uniqueName;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetImage([FromQuery]string fileName)
        {
            var get = new GetObjectRequest()
            {
                BucketName = "rtm-images",
                Key = fileName
            };

            using GetObjectResponse response = await _amazonS3.GetObjectAsync(get);
            using Stream responseStream = response.ResponseStream;
            var stream = new MemoryStream();
            await responseStream.CopyToAsync(stream);
            stream.Position = 0;

            return new FileStreamResult(stream, response.Headers["Content-Type"])
            {
                FileDownloadName = fileName
            };
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            var delete = new DeleteObjectRequest()
            {
                BucketName = "rtm-images",
                Key = fileName
            };

            await _amazonS3.DeleteObjectAsync(delete);

            return Ok();
        }
    }
}
