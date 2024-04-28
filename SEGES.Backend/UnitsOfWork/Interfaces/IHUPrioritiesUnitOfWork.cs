using SEGES.Shared.Entities;
using SEGES.Shared.Responses;


namespace SEGES.Backend.UnitsOfWork.Interfaces
{
    public interface IHUPrioritiesUnitOfWork
    {
        Task<ActionResponse<HUPriority>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<HUPriority>>> GetAsync();
    }
}
