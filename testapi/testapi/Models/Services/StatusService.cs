using API.Models.Entities;

namespace API.Models.Services
{
    public class StatusService
    {
        private readonly Progetto_FormativoContext _context;
        public StatusService(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public Status? GetStatusByName(string? name)
        {
            return _context.Statuses.Where(x => x.StatusName.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }
    }
}
