using SEGES.Backend.Repositories.Implementations;
using SEGES.Backend.UnitsOfWork.Implementations;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using SEGES.Shared;
using Microsoft.EntityFrameworkCore;

namespace SEGES.Backend.Repositories.Interfaces
{
    public class HUPrioritiesRepository : GenericRepository<HUPriority>, IHUPrioritiesRepository
    {
        private readonly DataContext _context;
        public HUPrioritiesRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<ActionResponse<HUPriority>> GetAsync(int id)
        {
            var priority = await _context.HUPriorities.FindAsync(id);
            if (priority == null)
            {
                return new ActionResponse<HUPriority>
                {
                    WasSuccess = false,
                    Message = "Prioridad no existe"
                };
            }
            return new ActionResponse<HUPriority>
            {
                WasSuccess = true,
                Result = priority
            };
        }

        public override async Task<ActionResponse<IEnumerable<HUPriority>>> GetAsync()
        {
            var priorities = await _context.HUPriorities.ToListAsync();
            return new ActionResponse<IEnumerable<HUPriority>>
            {
                WasSuccess = true,
                Result = priorities
            };
        }
    }
}
