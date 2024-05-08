using SEGES.Shared.DTOs;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.Repositories.Interfaces
{
    public interface IDocTraceabilityTypesRepository
    {
        Task<ActionResponse<DocTraceabilityType>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<DocTraceabilityType>>> GetAsync();
        Task<ActionResponse<IEnumerable<DocTraceabilityType>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
