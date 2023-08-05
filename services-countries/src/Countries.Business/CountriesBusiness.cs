using Countries.ApplicationCore.Interfaces;
using Countries.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Countries.Business;

public class CountriesBusiness : ICountriesBusiness
{
    private readonly ICountriesRepository _countriesRepository;
    private readonly ILogger<CountriesBusiness> _logger;

    public CountriesBusiness(ICountriesRepository countriesRepository, ILogger<CountriesBusiness> logger)
    {
        _countriesRepository = countriesRepository ?? throw new ArgumentNullException(nameof(countriesRepository));

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<IReadOnlyCollection<CountryInfo>> GetAllCountries()
    {
        _logger.LogInformation($"Starting CountriesBusiness::GetAllCountries()");

        return await _countriesRepository.GetAllCountries();
    }
}