using Microsoft.EntityFrameworkCore;
using MidStore.Data.Models;

namespace MidStore.Data.Api;

public static class PurchaseEndpoints
{
    public static void MapPurchaseEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Purchase").WithTags(nameof(Purchase));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            if (db.Purchase != null)
            {
                return await db.Purchase.AsNoTracking().ToListAsync();
            }
            else
            {
                return null;
            }
        })
        .WithName("GetAllPurchase")
        .WithOpenApi();

        group.MapGet("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Purchase != null)
            {
                return await db.Purchase.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id);
            }
            else
            {
                return null;
            }
        })
        .WithName("GetPurchaseById")
        .WithOpenApi();

        group.MapPut("/{id}", async (Guid id, Purchase purchase, ApplicationDbContext db) =>
        {
            if (db.Purchase != null)
            {
                await db.Purchase
                .Where(model => model.Id == id).AsNoTracking().ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, purchase.Id)
                    .SetProperty(m => m.UserId, purchase.UserId)
                     .SetProperty(m => m.MediaId, purchase.MediaId)
                    .SetProperty(m => m.PurchaseDateTime, purchase.PurchaseDateTime)
                    );
            }

        })
        .WithName("UpdatePurchase")
        .WithOpenApi();

        group.MapPost("/", async (Purchase purchase, ApplicationDbContext db) =>
        {
            db.Purchase?.Add(purchase);
            await db.SaveChangesAsync();
            return purchase.Id;
        })
        .WithName("CreatePurchase")
        .WithOpenApi();

        group.MapDelete("/{id}", async (Guid id, ApplicationDbContext db) =>
        {
            if (db.Purchase != null)
            {
                await db.Purchase.Where(model => model.Id == id).AsNoTracking().ExecuteDeleteAsync();
            }
        })
        .WithName("DeletePurchase")
        .WithOpenApi();
    }
}