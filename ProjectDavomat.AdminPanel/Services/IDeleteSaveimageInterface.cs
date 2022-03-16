using Microsoft.AspNetCore.Http;

namespace ProjectDavomat.AdminPanel.Services
{
    public interface IDeleteSaveimageInterface
    {
        string SaveImage(IFormFile formFile);
        bool DeleteImage(string fileName);
    }
}
