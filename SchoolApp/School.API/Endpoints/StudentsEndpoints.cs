using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Persistence;

namespace School.API.Endpoints;

public static class StudentsEndpoints
{
    private const string RoutePrefix = "/api/Students";

    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(RoutePrefix).WithTags(nameof(Student));

        group.MapGet("/", async (SchoolAppDbContext db) =>
        {
            return await db.Students.ToListAsync();
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Student>, NotFound>> (Guid id, SchoolAppDbContext db) =>
        {
            return await db.Students.FindAsync(id)
                is Student model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (Guid id, Student student, SchoolAppDbContext db) =>
        {
            var foundModel = await db.Students.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            db.Update(student);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", async (Student student, SchoolAppDbContext db) =>
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Student/{student.Id}", student);
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<Student>, NotFound>> (Guid id, SchoolAppDbContext db) =>
        {
            if (await db.Students.FindAsync(id) is Student student)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return TypedResults.Ok(student);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
