using API.Models.DTO;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public class CountryService
    {
        private readonly Progetto_FormativoContext _context;
        public CountryService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public async Task<Country?> GetCountryByName(string? name)
        {
            return await _context.Countries.Where(x => x.CountryName.Equals(name)).FirstOrDefaultAsync();
        }
        public async Task<List<CountryDTOGet>> GetAllCountry()
        {
            var list = await _context.Countries.ToListAsync();
            if (list.Any())
                return list.Select(x => new CountryDTOGet() {CountryID=x.CountryID,CountryName=x.CountryName,ISOCountry=x.ISOCode }).ToList();
            return new List<CountryDTOGet>();
        }
    }
}
