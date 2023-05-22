using Meinhardt.HSSE.Server.Pages;
using Meinhardt.Models.Storage;

namespace Meinhardt.HSSE.Server.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>?> GetCountry();
        Task<Country?> GetCountry(int Id);
        Task<Country?> UpdateCountry(Country updatedCountry); 
        Task<Country?> AddCountry(Country newCountry); 
    }
}
