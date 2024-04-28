using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.Repositories.Interfaces
{
    public interface IHuAppruvalStatusRepository
    {
        Task<ActionResponse<HUApprovalStatus>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<HUApprovalStatus>>> GetAsync();
    }
}
