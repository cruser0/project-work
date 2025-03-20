using API.Models.DTO;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public class CostRegistryService
    {
        private readonly Progetto_FormativoContext _context;
        public CostRegistryService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public async  Task<CostRegistry?> GetCostRegistryByCode(string? name)
        {
            return await  _context.CostRegistries.Where(x => x.CostRegistryUniqueCode.Equals(name)).FirstOrDefaultAsync();
        }
        public async Task<List<CostRegistryDTOGet>> GetAllCostRegistryByCode()
        {
            var list=await _context.CostRegistries.ToListAsync();
            if(list.Any())
                return (List<CostRegistryDTOGet>)list.Select(x => Mapper.CostRegistryMapper.MapGet(x));
            return new List<CostRegistryDTOGet>();
        }
    }
}
