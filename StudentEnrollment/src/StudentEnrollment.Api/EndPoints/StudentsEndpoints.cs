using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Dtos.Student;
using StudentEnrollment.Data.Entities;
using StudentEnrollment.Data.Persistence;
namespace StudentEnrollment.Api.EndPoints;

public static class StudentsEndpoints
{
    public static void MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Students").WithTags(nameof(Student));

        _ = group.MapGet("/", async Task<IReadOnlyCollection<StudentDto>> ([FromServices] StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
            {
                return mapper.Map<IReadOnlyCollection<StudentDto>>(await db.Students.ToListAsync());
            })
            .WithName("GetAllStudents")
            .Produces<IReadOnlyCollection<StudentDto>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapGet("/{id}", async Task<Results<Ok<StudentDto>, NotFound>> (int id, StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
            {
                return await db.Students.AsNoTracking().FirstOrDefaultAsync(model => model.Id == id)
                                is Student model ? TypedResults.Ok(mapper.Map<StudentDto>(model)) : TypedResults.NotFound();
            })
            .WithName("GetStudentById")
            .Produces<StudentDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPost("/", async Task<Created<StudentDto>> (CreateStudentDto createStudentDto, StudentEnrollmentDbContext db, [FromServices] IMapper mapper) =>
            {
                var student = mapper.Map<Student>(createStudentDto);

                // These should come from Authentication
                student.CreatedBy = student.ModifiedBy = "Admin";
                student.CreatedDate = student.ModifiedDate = DateTime.Now;

                await db.Students.AddAsync(student);

                await db.SaveChangesAsync();

                return TypedResults.Created($"/api/Student/{student.Id}", mapper.Map<StudentDto>(student));
            })
            .WithName("CreateStudent")
            .Produces<StudentDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Student student, StudentEnrollmentDbContext db) =>
        {
            var affected = await db.Students
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.FirstName, student.FirstName)
                  .SetProperty(m => m.LastName, student.LastName)
                  .SetProperty(m => m.DateOfBirth, student.DateOfBirth)
                  .SetProperty(m => m.IdNumber, student.IdNumber)
                  .SetProperty(m => m.Picture, student.Picture)
                  .SetProperty(m => m.Id, student.Id)
                  .SetProperty(m => m.CreatedDate, student.CreatedDate)
                  .SetProperty(m => m.CreatedBy, student.CreatedBy)
                  .SetProperty(m => m.ModifiedDate, student.ModifiedDate)
                  .SetProperty(m => m.ModifiedBy, student.ModifiedBy)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        _ = group.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> (int id, StudentEnrollmentDbContext db) =>
            {
                var affected = await db.Students.Where(model => model.Id == id).ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.NoContent() : TypedResults.NotFound();
            })
            .WithName("DeleteStudent")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();
    }
}
