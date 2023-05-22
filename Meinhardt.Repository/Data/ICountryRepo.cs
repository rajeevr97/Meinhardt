using Meinhardt.Models.Storage;
using System;
using System.Linq;

namespace Meinhardt.Repository.Data
{
    public interface ICountryRepo
    {
        Task<IEnumerable<Country>> GetCountry();
        Task<Country?> GetCountry(int Id);
        Task<Country> AddCountry(Country country);

        Task<bool> UpdateCountry(Country country);
        Task DeleteCountry(int Id);

    }
}
