using Microsoft.AspNetCore.Components.Forms;

namespace MidStore.Data.Controllers
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IBrowserFile file);
    }

    public class FileUploadService(IWebHostEnvironment webHostEnvironment) : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new(file.Name);
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            var folderDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "useruploads", "files");
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            var filePath = Path.Combine(folderDirectory, fileName);
            await using FileStream fs = new(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);
            var fullPath = $"/useruploads/files/{fileName}";
            return fullPath;
        }
    }    
}