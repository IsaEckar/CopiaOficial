using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.Repositories.Interfaces
{
    public interface IHUPrioritiesRepository
    {
        Task<ActionResponse<HUPriority>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<HUPriority>>> GetAsync();
    }
}
