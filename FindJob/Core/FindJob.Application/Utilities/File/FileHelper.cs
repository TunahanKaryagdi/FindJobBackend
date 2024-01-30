using FindJob.Application.Utilities.Enums;
using FindJob.Application.Utilities.File;
using Microsoft.AspNetCore.Http;

namespace FindJob.Persistence.Services
{
    public class FileHelper : IFileHelper
    {

        public const string root = "wwwroot/Images/";
        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string Update(IFormFile file, string path, ImageType type)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return Upload(file, type);
        }

        public string Upload(IFormFile file, ImageType type)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string filePath = "";
                if (type == ImageType.User)
                {
                    filePath = "Users/" + guid + extension;
                }
                else
                {
                    filePath = "Companies/" + guid + extension;
                }
                //string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }



}
