using Meinhardt.Models.Storage;
using Microsoft.EntityFrameworkCore;

namespace Meinhardt.Repository.Data
{
    public class CountryRepo : ICountryRepo
    {
        private readonly AppDbContext appDbContext;

        public CountryRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Country>> GetCountry()
        {
            return await appDbContext.Country.ToListAsync();
        }

        public async Task<Country?> GetCountry(int Id)
        {
            return await appDbContext.Country
                .FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<Country> AddCountry(Country country)
        {
            var result = await appDbContext.Country.AddAsync(country);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateCountry(Country country)
        {
            //var result = await appDbContext.Country
            //    .FirstOrDefaultAsync(e => e.Id == country.Id);

            if (appDbContext.Country.Any(f=>f.Id==country.Id))
            {
                appDbContext.Entry(country).State = EntityState.Modified;
                //result.Name = country.Name;
                //result.Code1 = country.Code1;
                //result.Code2 = country.Code2;

               await appDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task DeleteCountry(int Id)
        {
            var result = await appDbContext.Country
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                appDbContext.Country.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
