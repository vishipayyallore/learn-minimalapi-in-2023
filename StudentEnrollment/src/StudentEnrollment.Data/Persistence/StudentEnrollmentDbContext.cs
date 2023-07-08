﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Entities;

namespace StudentEnrollment.Data.Persistence;

public class StudentEnrollmentDbContext : IdentityDbContext
{
    public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //builder.ApplyConfiguration(new CourseConfiguration());
        //builder.ApplyConfiguration(new RoleConfiguration());
        //builder.ApplyConfiguration(new SchoolUserConfiguration());
        //builder.ApplyConfiguration(new UserRoleConfiguration());
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
}

//public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<StudentEnrollmentDbContext>
//{
//    public StudentEnrollmentDbContext CreateDbContext(string[] args)
//    {
//        // Get environment
//        //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//        // Build config
//        IConfiguration config = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .Build();

//        // Get connection string
//        var optionsBuilder = new DbContextOptionsBuilder<StudentEnrollmentDbContext>();
//        var connectionString = config.GetConnectionString("StudentEnrollmentDbConnection");
//        optionsBuilder.UseSqlServer(connectionString);
//        return new StudentEnrollmentDbContext(optionsBuilder.Options);
//    }
//}