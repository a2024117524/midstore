using Microsoft.EntityFrameworkCore;
using MidStore.Data.Models;

namespace MidStore.Data.Api;

public static class MediaGenreEndpoints
{
    public static void MapMediaGenreEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/MediaGenre").WithTags(nameof(MediaGenre));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            if (db.MediaGenre != null)
            {
                return await db.MediaGenre.AsNoTracking().ToListAsync();
            }
            else
            {
                return null;
            }
        })
        .WithName("GetAllMediaGenre")
        .WithOpenApi();

        group.MapGet("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.MediaGenre != null)
            {
                return await db.MediaGenre.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);
            }
            else
            {
                return null;
            }
        })
        .WithName("GetMediaGenreById")
        .WithOpenApi();

        group.MapPut("/{id}", async (Guid id, MediaGenre mediagenre, ApplicationDbContext db) =>
        {
            if (db.MediaGenre != null)
            {
                await db.MediaGenre.Where(model => model.Id == id).AsNoTracking().ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, mediagenre.Id)
                    .SetProperty(m => m.GenreId, mediagenre.GenreId)
                    .SetProperty(m => m.MediaId, mediagenre.MediaId)
                    );
            }
        })
        .WithName("UpdateMediaGenre")
        .WithOpenApi();

        group.MapPost("/", async (MediaGenre mediagenre, ApplicationDbContext db) =>
        {
            db.MediaGenre?.Add(mediagenre);
            await db.SaveChangesAsync();
            return mediagenre.Id;
        })
        .WithName("CreateMediaGenre")
        .WithOpenApi();

        group.MapDelete("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.MediaGenre != null)
            {
                await db.MediaGenre.Where(model => model.Id == id).AsNoTracking().ExecuteDeleteAsync();
            }
        })
        .WithName("DeleteMediaGenre")
        .WithOpenApi();
    }
}