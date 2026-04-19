using Microsoft.EntityFrameworkCore;
using MidStore.Data.Models;

namespace MidStore.Data.Api;

public static class IndustryEndpoints
{
    public static void MapIndustryEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Industry").WithTags(nameof(Industry));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            if (db.Industry != null)
            {
                return await db.Industry.AsNoTracking().ToListAsync();
            }
            else
            {
                return null;
            }
        })
        .WithName("GetAllIndustry")
        .WithOpenApi();

        group.MapGet("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Industry != null)
            {
                return await db.Industry.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);
            }
            else
            {
                return null;
            }
        })
        .WithName("GetIndustryById")
        .WithOpenApi();

        group.MapPut("/{id}", async (Guid id, Industry industry, ApplicationDbContext db) =>
        {
            if (db.Industry != null)
            {
                await db.Industry.Where(model => model.Id == id).AsNoTracking().ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, industry.Id)
                    .SetProperty(m => m.Label, industry.Label)
                    );
            }
        })
        .WithName("UpdateIndustry")
        .WithOpenApi();

        group.MapPost("/", async (Industry industry, ApplicationDbContext db) =>
        {
            db.Industry?.Add(industry);
            await db.SaveChangesAsync();
            return industry.Id;
        })
        .WithName("CreateIndustry")
        .WithOpenApi();

        group.MapDelete("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Industry != null)
            {
                await db.Industry.Where(model => model.Id == id).AsNoTracking().ExecuteDeleteAsync();
            }
        })
        .WithName("DeleteIndustry")
        .WithOpenApi();
    }
}