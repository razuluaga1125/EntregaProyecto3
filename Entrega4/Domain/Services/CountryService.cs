using Microsoft.EntityFrameworkCore;
using _3ra_entrega.DAL;
using _3ra_entrega.DAL.Entities;
using _3ra_entrega.Domain.interfaces;

namespace _3ra_entrega.Domain.services
{
    public class CountryService : ICountryService
    {
        //inyeccion de dependencia 
        private readonly DataBaseContext _context;
        public CountryService(DataBaseContext context)
        {
            try
            {
                _context = context;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }
        
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {            
                var countries = await _context.Countries.ToListAsync();
                return countries;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }

        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {            
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
                //otras formas 
                var country2 = await _context.Countries.FindAsync(id);
                var country3 = await _context.Countries.FirstAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }

        }

        public async Task<Country> CreateCountryAsync(Country country)
        {

            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now; _context.Countries.Add(country); /*me permite crear el objeto en la db*/
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiefDate = DateTime.Now;
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> DeletCountryAsync(Guid id)
        {
            try
            {
                var country =await GetCountryByIdAsync( id);
                if (country == null)
                {
                    return null;
                }
                 _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

    }
}
