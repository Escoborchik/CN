
namespace MangaMania.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public const string ROOT_FOLDER_NAME = "Assets";

        public FileService(IWebHostEnvironment env)
        {
            _environment = env;
        }

        /// <summary>
        /// Saves given image to "Assets" directory
        /// </summary>
        /// <param name="imageFile">Image file to save</param>
        /// <returns>saved file relative path</returns>
        public string SaveImage(IFormFile imageFile)
        {
            string[] allowedExtensions = new string[] { ".png", ".jpg", ".jpeg", ".webp" };

            try
            {
                string path = Path.Combine(_environment.ContentRootPath, ROOT_FOLDER_NAME);

                // extension check
                string ext = Path.GetExtension(imageFile.FileName);
                if (!allowedExtensions.Contains(ext))
                {
                    throw new Exception($"Only files with {string.Join(",", allowedExtensions)} extensions");
                }

                // name generation
                string uniqueString = Guid.NewGuid().ToString();
                string newFileName = uniqueString + ext;
                string fullRelativePath = Path.Combine(path, newFileName);
                string webRelativePath = Path.Combine("assets", newFileName);

                // save image
                FileStream stream = new FileStream(fullRelativePath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();

                return webRelativePath;
            }
            catch (Exception)
            {
                throw new Exception("Error ocured while file saving");
            }
        }

        /// <summary>
        /// Deletes file in "Assets" directory
        /// </summary>
        /// <param name="imageFileName">name of file in "Assets" directory</param>
        /// <returns>operation succeded of not</returns>
        public bool DeleteImage(string imageFileName)
        {
            string path = Path.Combine(_environment.ContentRootPath, ROOT_FOLDER_NAME, imageFileName);

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
