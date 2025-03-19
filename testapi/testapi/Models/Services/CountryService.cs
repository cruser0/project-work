using API.Models.Entities;

namespace API.Models.Services
{
    public class CountryService
    {
        private readonly Progetto_FormativoContext _context;
        public CountryService(Progetto_FormativoContext ctx)
        {
            _context= ctx;
        }

        public Country? GetCountryByName(string? name)
        {
            return _context.Countries.Where(x=>x.CountryName.Equals(name)).FirstOrDefault();
        }
    }
}
