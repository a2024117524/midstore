using Microsoft.EntityFrameworkCore;
using MidStore.Data.Models;

namespace MidStore.Data.Api;

public static class MediaEndpoints
{
    public static void MapMediaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Media").WithTags(nameof(Media));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            if (db.Media != null)
            {
                return await db.Media.AsNoTracking().ToListAsync();
            }
            else
            {
                return null;
            }
        })
        .WithName("GetAllMedia")
        .WithOpenApi();

        group.MapGet("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Media != null)
            {
                return await db.Media.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);
            }
            else
            {
                return null;
            }
        })
        .WithName("GetMediaById")
        .WithOpenApi();

        group.MapPut("/{id}", async (Guid id, Media media, ApplicationDbContext db) =>
        {
            if (db.Media != null)
            {
                await db.Media.Where(model => model.Id == id).AsNoTracking().ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, media.Id)
                    .SetProperty(m => m.UserId, media.UserId)
                    .SetProperty(m => m.UserName, media.UserName)
                    .SetProperty(m => m.UploadDateTime, media.UploadDateTime)
                    .SetProperty(m => m.Title, media.Title)
                    .SetProperty(m => m.Description, media.Description)
                    .SetProperty(m => m.Price, media.Price)
                    .SetProperty(m => m.Explicit, media.Explicit)
                    .SetProperty(m => m.Private, media.Private)
                    .SetProperty(m => m.Cover, media.Cover)
                    .SetProperty(m => m.File, media.File)
                    );
            }          
        })
        .WithName("UpdateMedia")
        .WithOpenApi();

        group.MapPost("/", async (Media media, ApplicationDbContext db) =>
        {
            db.Media?.Add(media);
            await db.SaveChangesAsync();
            return media.Id;
        })
        .WithName("CreateMedia")
        .WithOpenApi();

        group.MapDelete("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Media != null)
            {
                await db.Media.Where(model => model.Id == id).AsNoTracking().ExecuteDeleteAsync();
            }        
        })
        .WithName("DeleteMedia")
        .WithOpenApi();
    }
}