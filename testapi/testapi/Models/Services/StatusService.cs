using Entity_Validator.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Services
{
    public interface IStatusService
    {
        Task<Status?> GetStatusByName(string? name);
    }
    public class StatusService : IStatusService
    {
        private readonly Progetto_FormativoContext _context;
        public StatusService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public async Task<Status?> GetStatusByName(string? name)
        {
            return await _context.Statuses.Where(x => x.StatusName.ToLower().Equals(name.ToLower())).FirstOrDefaultAsync();
        }
    }
}
