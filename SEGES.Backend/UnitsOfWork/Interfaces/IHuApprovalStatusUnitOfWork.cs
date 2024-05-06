using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using SEGES.Shared.DTOs;

namespace SEGES.Backend.UnitsOfWork.Interfaces
{
    public interface IHuApprovalStatusUnitOfWork
    {
        Task<ActionResponse<HUApprovalStatus>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<HUApprovalStatus>>> GetAsync();
        Task<ActionResponse<IEnumerable<HUApprovalStatus>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);

    }
}
