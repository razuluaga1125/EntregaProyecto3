using _3ra_entrega.DAL.Entities;

namespace _3ra_entrega.Domain.interfaces
{
    public interface ICountryService
    {
        Task <IEnumerable<Country>> GetCountriesAsync(); // es una firma de metodos
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeletCountryAsync(Guid id);
    }
}