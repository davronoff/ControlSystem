using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ProjectDavomat.AdminPanel.Services
{
    public interface IDeleteSaveimageInterface
    {
        Task<string> SaveImageAsync(IFormFile formFile);
        Task<bool> DeleteImageAsync(string fileName);
    }
}
