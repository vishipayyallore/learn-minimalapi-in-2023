using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace School.Persistence;

public class StudentEnrollmentDbContextFactory : IDesignTimeDbContextFactory<SchoolAppDbContext>
{
    public SchoolAppDbContext CreateDbContext(string[] args)
    {
        // Get environment
        //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        // Build config
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Get connection string
        var optionsBuilder = new DbContextOptionsBuilder<SchoolAppDbContext>();
        var connectionString = config.GetConnectionString("SchoolAppDbConnection");
        optionsBuilder.UseSqlServer(connectionString);
        return new SchoolAppDbContext(optionsBuilder.Options);
    }
}