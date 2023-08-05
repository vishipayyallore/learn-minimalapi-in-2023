using Countries.Data.Entities;

namespace Countries.ApplicationCore.Interfaces;

public interface ICountriesBusiness
{
    Task<IReadOnlyCollection<CountryInfo>> GetAllCountries();
}
