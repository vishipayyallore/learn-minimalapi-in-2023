﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Dtos.Student;
using StudentEnrollment.Data.Entities;
namespace StudentEnrollment.Api.EndPoints;

public static class StudentsEndpoints
{
    public static void MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {
        const string apiRoute = "/api/Students";

        var group = routes.MapGroup(apiRoute).WithTags(nameof(Student));

        _ = group.MapGet("/", async Task<IReadOnlyCollection<StudentDto>> ([FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper) =>
            {
                return mapper.Map<IReadOnlyCollection<StudentDto>>(await studentRepository.GetAllAsync());
            })
            .WithName("GetAllStudents")
            .Produces<IReadOnlyCollection<StudentDto>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapGet("/{id}", async Task<Results<Ok<StudentDto>, NotFound>> ([FromRoute] int id, [FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper) =>
            {
                return await studentRepository.GetAsync(id) is Student student
                        ? TypedResults.Ok(mapper.Map<StudentDto>(student))
                        : TypedResults.NotFound();
            })
            .WithName("GetStudentById")
            .Produces<StudentDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapGet("/GetDetails/{id}", async Task<Results<Ok<StudentDetailsDto>, NotFound>> ([FromRoute] int id, [FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper) =>
            {
                return await studentRepository.GetStudentDetails(id) is Student student
                        ? TypedResults.Ok(mapper.Map<StudentDetailsDto>(student))
                        : TypedResults.NotFound();
            })
            .WithName("GetStudentDetailsById")
            .Produces<StudentDto>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPost("/", async Task<Created<StudentDto>> ([FromBody] CreateStudentDto createStudentDto, [FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper) =>
            {
                var student = mapper.Map<Student>(createStudentDto);

                // These should come from Authentication
                student.CreatedBy = student.ModifiedBy = "Admin";
                student.CreatedDate = student.ModifiedDate = DateTime.Now;

                await studentRepository.AddAsync(student);

                return TypedResults.Created($"{apiRoute}/{student.Id}", mapper.Map<StudentDto>(student));
            })
            .WithName("CreateStudent")
            .Produces<StudentDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapPut("/{id}", async Task<Results<NoContent, NotFound>> ([FromRoute] int id, [FromBody] StudentDto studentDto, [FromServices] IStudentRepository studentRepository, [FromServices] IMapper mapper) =>
            {
                var existingStudent = await studentRepository.GetAsync(id);
                if (existingStudent is null)
                {
                    return TypedResults.NotFound();
                }

                mapper.Map(studentDto, existingStudent);

                // These should come from Authentication
                existingStudent.ModifiedBy = "Admin";
                existingStudent.ModifiedDate = DateTime.Now;

                await studentRepository.UpdateAsync(existingStudent);

                return TypedResults.NoContent();
            })
            .WithName("UpdateStudent")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();

        _ = group.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> ([FromRoute] int id, [FromServices] IStudentRepository studentRepository) =>
            {
                return await studentRepository.DeleteAsync(id) ? TypedResults.NoContent() : TypedResults.NotFound();
            })
            .WithName("DeleteStudent")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi();
    }
}
