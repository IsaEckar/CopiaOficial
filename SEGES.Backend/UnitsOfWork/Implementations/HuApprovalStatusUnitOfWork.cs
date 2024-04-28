using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.UnitsOfWork.Implementations
{
    public class HuApprovalStatusUnitOfWork : GenericUnitOfWork<HUApprovalStatus>, IHuApprovalStatusUnitOfWork
    {
        private readonly IHuAppruvalStatusRepository _huAppruvalStatusRepository;
        public HuApprovalStatusUnitOfWork(IGenericRepository<HUApprovalStatus> repository, IHuAppruvalStatusRepository huAppruvalStatusRepository) : base(repository)
        {
            _huAppruvalStatusRepository = huAppruvalStatusRepository;
        }

        public override async Task<ActionResponse<HUApprovalStatus>> GetAsync(int id) => await _huAppruvalStatusRepository.GetAsync(id);
        public override async Task<ActionResponse<IEnumerable<HUApprovalStatus>>> GetAsync() => await _huAppruvalStatusRepository.GetAsync();
    }
}
