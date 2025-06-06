using Microsoft.AspNetCore.Mvc;
using _3ra_entrega.DAL.ENTITIES;
using _3ra_entrega.Domain.Interfaces;

namespace _3ra_entrega.Controllers
{
    [Route("api/[controller]")] //esta es el nombre inicial de mi RUTA, URL o PATH
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService) { 
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]

        public async Task<ActionResult<IEnumerable<Country>>> GetConuntriesAsync() //NUMERABLE COUNTRIES
        {
            var conuntries = await _countryService.GetConuntriesAsync();
            if (conuntries == null || !conuntries.Any())
            {
                return NotFound();
            }
            return Ok(conuntries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL: api/conuntries/get

        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id) //VIEW COUNTRIES
        {
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]

        public async  Task<ActionResult<Country>> CreateCountryAsync(Country country) //CREATE COUNTRY
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null) return NotFound();
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                        return Conflict(String.Format("{0} ya existe", country.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]

        public async Task<ActionResult<Country>> EditCountryAsync(Country country) //EDIT COUNTRY
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);
                if (editedCountry == null) return NotFound();
                return Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", country.Name));
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]

        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)// DELETE COUNTRY
        {
            if (id == null) return BadRequest();
            var deleteCountry = await _countryService.DeleteCountryAsync(id);
            if (deleteCountry == null) return NotFound();
            return Ok(deleteCountry);
        }
    }
}