namespace MangaMania.Services
{
    public interface IFileService
    {
        public string SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
