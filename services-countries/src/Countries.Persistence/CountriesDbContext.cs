using Countries.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Countries.Persistence;

public class CountriesDbContext : DbContext
{

    public CountriesDbContext(DbContextOptions<CountriesDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<CountryInfo> CountriesInfo => Set<CountryInfo>();
}