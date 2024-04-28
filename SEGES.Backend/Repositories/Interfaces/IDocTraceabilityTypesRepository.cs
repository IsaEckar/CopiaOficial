using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.Repositories.Interfaces
{
    public interface IDocTraceabilityTypesRepository
    {
        Task<ActionResponse<DocTraceabilityType>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<DocTraceabilityType>>> GetAsync();
    }
}
