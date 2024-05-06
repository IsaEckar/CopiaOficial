using SEGES.Shared.DTOs;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.Repositories.Interfaces
{
    public interface IHUStatusRepository
    {
        Task<ActionResponse<HUStatus>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<HUStatus>>> GetAsync();
        Task<ActionResponse<IEnumerable<HUStatus>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
