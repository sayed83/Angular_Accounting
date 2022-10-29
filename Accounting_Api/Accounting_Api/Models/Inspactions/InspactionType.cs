using System.ComponentModel.DataAnnotations;
using Accounting_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Api.Models.Inspactions
{
    public class InspactionType
    {
        public int InspactionTypeId { get; set; }
        [StringLength(20)]
        public string InspactionName { get; set; } = string.Empty;
    }


public static class InspactionTypeEndpoints
{
	public static void MapInspactionTypeEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/InspactionType", async (DBContext db) =>
        {
            return await db.InspactionTypes.ToListAsync();
        })
        .WithName("GetAllInspactionTypes");

        routes.MapGet("/api/InspactionType/{id}", async (int InspactionTypeId, DBContext db) =>
        {
            return await db.InspactionTypes.FindAsync(InspactionTypeId)
                is InspactionType model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetInspactionTypeById");

        routes.MapPut("/api/InspactionType/{id}", async (int InspactionTypeId, InspactionType inspactionType, DBContext db) =>
        {
            var foundModel = await db.InspactionTypes.FindAsync(InspactionTypeId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateInspactionType");

        routes.MapPost("/api/InspactionType/", async (InspactionType inspactionType, DBContext db) =>
        {
            db.InspactionTypes.Add(inspactionType);
            await db.SaveChangesAsync();
            return Results.Created($"/InspactionTypes/{inspactionType.InspactionTypeId}", inspactionType);
        })
        .WithName("CreateInspactionType");


        routes.MapDelete("/api/InspactionType/{id}", async (int InspactionTypeId, DBContext db) =>
        {
            if (await db.InspactionTypes.FindAsync(InspactionTypeId) is InspactionType inspactionType)
            {
                db.InspactionTypes.Remove(inspactionType);
                await db.SaveChangesAsync();
                return Results.Ok(inspactionType);
            }

            return Results.NotFound();
        })
        .WithName("DeleteInspactionType");
    }
}}
