using Microsoft.AspNetCore.Http;
using ProjectDavomat.Domain;
using System.Net.Http;
using System.Threading.Tasks;

namespace DavomatProject.Api.Services
{
    public interface IImageService
    {
        string SaveImage(IFormFile image);
        bool DeleteImage(string name);
    }
}
