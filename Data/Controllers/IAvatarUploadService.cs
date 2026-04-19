using Microsoft.AspNetCore.Components.Forms;

namespace MidStore.Data.Controllers
{
    public interface IAvatarUploadService
    {
        Task<string> UploadAvatar(IBrowserFile avatar);
    }  
    
    public class AvatarUploadService(IWebHostEnvironment webHostEnvironment) : IAvatarUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<string> UploadAvatar(IBrowserFile avatar)
        {
            FileInfo avatarInfo = new(avatar.Name);
            var avatarName = Guid.NewGuid().ToString() + avatarInfo.Extension;
            var folderDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "useruploads", "avatars");
            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            var avatarPath = Path.Combine(folderDirectory, avatarName);
            await using FileStream fs = new(avatarPath, FileMode.Create);
            await avatar.OpenReadStream().CopyToAsync(fs);
            var fullPath = $"/useruploads/avatars/{avatarName}";
            return fullPath;
        }
    }
}