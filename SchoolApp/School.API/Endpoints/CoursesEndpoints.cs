﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Persistence;
using static School.ApplicationCore.Common.Constants;

namespace School.API.Endpoints
{

    public static class CoursesEndpoints
    {

        public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
        {

            routes.MapGet(CourseEndpoints.Root, async ([FromServices] SchoolAppDbContext schoolAppDbContext) =>
            {
                return Results.Ok(await schoolAppDbContext.Courses.ToListAsync());
            }).AllowAnonymous()
              .WithTags(nameof(Course))
              .WithName("GetAllCourses")
              .Produces<List<Course>>(StatusCodes.Status200OK);

            routes.MapGet(CourseEndpoints.ActionById, async ([FromServices] SchoolAppDbContext schoolAppDbContext, Guid Id) =>
            {
                return await schoolAppDbContext.Courses.FindAsync(Id) is Course course ? Results.Ok(course) : Results.NotFound();
            }).AllowAnonymous()
              .WithTags(nameof(Course))
              .WithName("GetCourseById")
              .Produces<Course>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);

            routes.MapPost(CourseEndpoints.Root, async ([FromServices] SchoolAppDbContext schoolAppDbContext, [FromBody] Course course) =>
            {
                await schoolAppDbContext.Courses.AddAsync(course);
                await schoolAppDbContext.SaveChangesAsync();

                return Results.Created($"{CourseEndpoints.Root}/{course.Id}", course);
            }).WithTags(nameof(Course))
              .WithName("AddCourse")
              .Produces<Course>(StatusCodes.Status201Created);

            routes.MapPut(CourseEndpoints.Root, async ([FromServices] SchoolAppDbContext schoolAppDbContext, [FromBody] Course course, Guid Id) =>
            {
                var courseExists = await schoolAppDbContext.Courses.AnyAsync(r => r.Id == Id);
                if (!courseExists)
                {
                    return Results.NotFound();
                }

                schoolAppDbContext.Update(course);
                await schoolAppDbContext.SaveChangesAsync();

                return Results.NoContent();
            }).WithTags(nameof(Course))
              .WithName("UpdateCourseById")
              .Produces(StatusCodes.Status404NotFound)
              .Produces(StatusCodes.Status204NoContent);

            routes.MapDelete(CourseEndpoints.ActionById, async ([FromServices] SchoolAppDbContext schoolAppDbContext, Guid Id) =>
            {
                var course = await schoolAppDbContext.Courses.FindAsync(Id);
                if (course is null)
                {
                    return Results.NotFound();
                }

                schoolAppDbContext.Remove(course);
                await schoolAppDbContext.SaveChangesAsync();

                return Results.NoContent();
            }).WithTags(nameof(Course))
              .WithName("DeleteCourseById")
              .Produces<Course>(StatusCodes.Status204NoContent)
              .Produces(StatusCodes.Status404NotFound);
        }


    }

}