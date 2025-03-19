using API.Models.Entities;

namespace API.Models.Services
{
    public class CostRegistryService
    {
        private readonly Progetto_FormativoContext _context;
        public CostRegistryService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public CostRegistry GetCostRegistryByCode(string name)
        {
            return _context.CostRegistries.Where(x => x.CostRegistryUniqueCode.Equals(name)).First();
        }
    }
}
