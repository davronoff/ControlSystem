using ProjectDavomat.Domain;

namespace DavomatProject.Api.Services
{
    public interface IImageService
    {
        string SaveImage(ImageModel image);
        bool DeleteImage(string name);
    }
}
