using Meinhardt.Models.Storage;
using Meinhardt.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace Meinhardt.HSSE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepo _CountryRepo;

        public CountriesController(ICountryRepo countryRepo)
        {
            _CountryRepo = countryRepo;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            try
            {
                return Ok(await _CountryRepo.GetCountry());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _CountryRepo.GetCountry(id);

            try
            {
                if (country == null)
                {
                    return NotFound();
                }

                //return Ok(country);
                return country;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // PUT: api/Countries/5
        [HttpPut]
        public async Task<IActionResult> PutCountry(Country country)
        {
            try
            {
                var result = await _CountryRepo.UpdateCountry(country);
                if (result)
                {
                    return Ok(country);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return NotFound();
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            try
            {
                if (country == null)
                {
                    return BadRequest();
                }
                var result = await _CountryRepo.AddCountry(country);

                return CreatedAtAction(nameof(GetCountry), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _CountryRepo.DeleteCountry(id);
            return Ok();
        }









        //private bool CountryExists(int id)
        //{
        //    return (_CountryRepo.GetCountry(id).Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
