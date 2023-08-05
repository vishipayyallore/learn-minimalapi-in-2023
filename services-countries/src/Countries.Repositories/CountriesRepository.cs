using Countries.ApplicationCore.Interfaces;
using Countries.Data.Entities;
using Countries.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Countries.Repositories;

public class CountriesRepository : ICountriesRepository
{
    private readonly CountriesDbContext _countriesDbContext;
    private readonly ILogger<CountriesRepository> _logger;

    public CountriesRepository(CountriesDbContext countriesDbContext, ILogger<CountriesRepository> logger)
    {
        _countriesDbContext = countriesDbContext ?? throw new ArgumentNullException(nameof(countriesDbContext));

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IReadOnlyCollection<CountryInfo>> GetAllCountries()
    {
        _logger.LogInformation($"Starting CountriesRepository::GetAllCountries()");

        return await _countriesDbContext.CountriesInfo.ToListAsync();
    }
}