using SEGES.Shared.DTOs;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEGES.Backend.Repositories.Interfaces
{
    public interface IHUPrioritiesRepository
    {
        Task<ActionResponse<HUPriority>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<HUPriority>>> GetAsync();
        Task<ActionResponse<IEnumerable<HUPriority>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);

    }
}
