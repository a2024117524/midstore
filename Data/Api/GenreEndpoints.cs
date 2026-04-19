using Microsoft.EntityFrameworkCore;
using MidStore.Data.Models;

namespace MidStore.Data.Api;

public static class GenreEndpoints
{
    public static void MapGenreEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Genre").WithTags(nameof(Genre));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            if (db.Genre != null)
            {
                return await db.Genre.AsNoTracking().ToListAsync();
            }
            else
            {
                return null;
            }
        })
        .WithName("GetAllGenre")
        .WithOpenApi();

        group.MapGet("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Genre != null)
            {
                return await db.Genre.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);
            }
            else
            {
                return null;
            }
        })
        .WithName("GetGenreById")
        .WithOpenApi();

        group.MapPut("/{id}", async (Guid id, Genre genre, ApplicationDbContext db) =>
        {
            if (db.Genre != null)
            {
                await db.Genre.Where(model => model.Id == id).AsNoTracking().ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, genre.Id)
                    .SetProperty(m => m.IndustryId, genre.IndustryId)
                    .SetProperty(m => m.Tag, genre.Tag)
                    );
            }
        })
        .WithName("UpdateGenre")
        .WithOpenApi();

        group.MapPost("/", async (Genre genre, ApplicationDbContext db) =>
        {
            db.Genre?.Add(genre);
            await db.SaveChangesAsync();
            return genre.Id;
        })
        .WithName("CreateGenre")
        .WithOpenApi();

        group.MapDelete("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Genre != null)
            {
                await db.Genre.Where(model => model.Id == id).AsNoTracking().ExecuteDeleteAsync();
            }            
        })
        .WithName("DeleteGenre")
        .WithOpenApi();
    }
}