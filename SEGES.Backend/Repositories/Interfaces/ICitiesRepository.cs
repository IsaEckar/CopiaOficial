using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using SEGES.Shared.DTOs;

namespace SEGES.Backend.Repositories.Interfaces
{
    public interface ICitiesRepository
    {
        Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
        Task<IEnumerable<City>> GetComboAsync(int stateId);
    }

}
