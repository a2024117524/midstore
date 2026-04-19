using Microsoft.EntityFrameworkCore;
using MidStore.Data.Models;

namespace MidStore.Data.Api;

public static class ProfileEndpoints
{
    public static void MapProfileEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Profile").WithTags(nameof(Profile));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            if (db.Profile != null)
            {
                return await db.Profile.AsNoTracking().ToListAsync();
            }
            else
            {
                return null;
            }
        })
        .WithName("GetAllProfile")
        .WithOpenApi();

        group.MapGet("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Profile != null)
            {
                return await db.Profile.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);
            }
            else
            {
                return null;
            }
        })
        .WithName("GetProfileById")
        .WithOpenApi();

        group.MapPut("/{id}", async (Guid id, Profile profile, ApplicationDbContext db) =>
        {
            if (db.Profile != null)
            {
                await db.Profile
                .Where(model => model.Id == id).AsNoTracking().ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, profile.Id)
                    .SetProperty(m => m.UserId, profile.UserId)
                     .SetProperty(m => m.Avatar, profile.Avatar)
                    .SetProperty(m => m.Private, profile.Private)
                    .SetProperty(m => m.BirthDate, profile.BirthDate)
                    );
            }

        })
        .WithName("UpdateProfile")
        .WithOpenApi();

        group.MapPost("/", async (Profile profile, ApplicationDbContext db) =>
        {
            db.Profile?.Add(profile);
            await db.SaveChangesAsync();
            return profile.Id;
        })
        .WithName("CreateProfile")
        .WithOpenApi();

        group.MapDelete("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Profile != null)
            {
                await db.Profile.Where(model => model.Id == id).AsNoTracking().ExecuteDeleteAsync();
            }
        })
        .WithName("DeleteProfile")
        .WithOpenApi();
    }
}