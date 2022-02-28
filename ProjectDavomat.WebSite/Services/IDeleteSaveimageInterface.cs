using Microsoft.AspNetCore.Http;

namespace ProjectDavomat.WebSite.Services
{
    public interface IDeleteSaveimageInterface
    {
        string SaveImage(IFormFile formFile);
        bool DeleteImage(string fileName);
    }
}
