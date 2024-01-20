using Microsoft.AspNetCore.Http;

namespace FindJob.Application.Utilities.File
{
    public interface IFileHelper
    {

        string Upload(IFormFile file, ImageType type);
        void Delete(string path);
        string Update(IFormFile file, string path, ImageType type);

    }
}
