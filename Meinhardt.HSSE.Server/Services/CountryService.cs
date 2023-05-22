using Meinhardt.HSSE.Server.Pages;
using Meinhardt.Models.Storage;
using System.Net.Http.Json;

namespace Meinhardt.HSSE.Server.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Country?> AddCountry(Country addCountry)
        {
            var result = await _httpClient.PostAsJsonAsync<Country>($"api/Countries", addCountry);
            if (result.IsSuccessStatusCode)
            {
                var retval = await result.Content.ReadFromJsonAsync<Country>();
                return retval;
            }
            return null;
        }

        public async Task<IEnumerable<Country>?> GetCountry()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Country>>("api/Countries");
        }

        public async Task<Country?> GetCountry(int Id)
        {
            return await _httpClient.GetFromJsonAsync<Country>($"api/Countries/{Id}");
        }

        public async Task<Country?> UpdateCountry(Country updatedCountry)
        {
            var result = await _httpClient.PutAsJsonAsync<Country>($"api/Countries", updatedCountry);
            if (result.IsSuccessStatusCode)
            {
                var retval = await result.Content.ReadFromJsonAsync<Country>();
                return retval;
            }
            return null;
        }
    }
}
