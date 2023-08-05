using System.ComponentModel.DataAnnotations;

namespace Countries.Data.Entities;

public class CountryInfo
{
    [Key]
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public string? CapitalState { get; set; }

    public string? NationalBird { get; set; }

    public long CountryPopulation { get; set; }
}