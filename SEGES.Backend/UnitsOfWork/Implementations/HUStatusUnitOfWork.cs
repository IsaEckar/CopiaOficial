using SEGES.Backend.Controllers;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.DTOs;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.UnitsOfWork.Implementations
{
    public class HUStatusUnitOfWork : GenericUnitOfWork<HUStatus>, IHUStatusUnitOfWork
    {
        private readonly IHUStatusRepository _huStatusRepository;

        public HUStatusUnitOfWork(IGenericRepository<HUStatus> repository, IHUStatusRepository huStatusRepository) : base(repository)
        {
            _huStatusRepository = huStatusRepository;
        }

        public override async Task<ActionResponse<HUStatus>> GetAsync(int id) => await _huStatusRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<HUStatus>>> GetAsync() => await _huStatusRepository.GetAsync();

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _huStatusRepository.GetTotalPagesAsync(pagination);

        public override async Task<ActionResponse<IEnumerable<HUStatus>>> GetAsync(PaginationDTO pagination) => await _huStatusRepository.GetAsync(pagination);
    }
}