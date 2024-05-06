using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.DTOs;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.UnitsOfWork.Implementations
{
    public class DocTraceabilityTypesUnitOfWork : GenericUnitOfWork<DocTraceabilityType>, IDocTraceabilityTypesUnitOfWork
    {
        private readonly IDocTraceabilityTypesRepository _docTraceabilityTypesRepository;

        public DocTraceabilityTypesUnitOfWork(IGenericRepository<DocTraceabilityType> repository, IDocTraceabilityTypesRepository docTraceabilityTypesRepository) : base(repository)
        {
            _docTraceabilityTypesRepository = docTraceabilityTypesRepository;
        }

        public override async Task<ActionResponse<DocTraceabilityType>> GetAsync(int id) => await _docTraceabilityTypesRepository.GetAsync(id);


        public override async Task<ActionResponse<IEnumerable<DocTraceabilityType>>> GetAsync() => await _docTraceabilityTypesRepository.GetAsync();
        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _docTraceabilityTypesRepository.GetTotalPagesAsync(pagination);

        public override async Task<ActionResponse<IEnumerable<DocTraceabilityType>>> GetAsync(PaginationDTO pagination) => await _docTraceabilityTypesRepository.GetAsync(pagination);
    }
}
