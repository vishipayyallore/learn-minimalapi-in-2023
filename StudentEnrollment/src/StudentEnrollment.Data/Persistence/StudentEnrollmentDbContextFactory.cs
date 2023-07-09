using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StudentEnrollment.Data.Persistence;

public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<StudentEnrollmentDbContext>
{
    public StudentEnrollmentDbContext CreateDbContext(string[] args)
    {
        // Get environment
        //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        // Build config
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Get connection string
        var optionsBuilder = new DbContextOptionsBuilder<StudentEnrollmentDbContext>();
        var connectionString = config.GetConnectionString("StudentEnrollmentDbConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new StudentEnrollmentDbContext(optionsBuilder.Options);
    }
}