using Microsoft.AspNetCore.Components.Forms;

namespace MidStore.Data.Controllers
{
    public interface ICoverUploadService
    {
        Task<string> UploadCover(IBrowserFile cover);
    }

    public class CoverUploadService(IWebHostEnvironment webHostEnvironment) : ICoverUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<string> UploadCover(IBrowserFile cover)
        {
            FileInfo coverInfo = new(cover.Name);
            var coverName = Guid.NewGuid().ToString() + coverInfo.Extension;
            var folderDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "useruploads", "covers");
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            var coverPath = Path.Combine(folderDirectory, coverName);
            await using FileStream fs = new(coverPath, FileMode.Create);
            await cover.OpenReadStream().CopyToAsync(fs);
            var fullPath = $"/useruploads/covers/{coverName}";
            return fullPath;
        }
    }    
}