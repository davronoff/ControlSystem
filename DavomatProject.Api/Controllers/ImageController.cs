using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DavomatProject.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private string BucketName = "rtm-images";
        private IAmazonS3 client = new AmazonS3Client("AKIA2PK65C7G5XOEXK6D", "u6Kli+bvTuikKAGPK3WqP6dn0NBp8IKR8ZHQgupp", Amazon.RegionEndpoint.USEast1);

        [HttpPost]
        [Route("save")] 
        public async Task<string> UploadImage(IFormFile file)
        {
            string uniqueName = Guid.NewGuid().ToString() + file.FileName;
            var put = new PutObjectRequest()
            {
                BucketName = this.BucketName,
                Key = uniqueName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            await client.PutObjectAsync(put);
            uniqueName = "https://rtm-images.s3.amazonaws.com/" + uniqueName;


            return uniqueName;
        }
    }
}
