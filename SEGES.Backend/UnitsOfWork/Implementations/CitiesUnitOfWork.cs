using Microsoft.AspNetCore.Mvc;
using SEGES.Backend.Repositories.Implementations;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.DTOs;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;

namespace SEGES.Backend.UnitsOfWork.Implementations
{
    public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
    {
        private readonly ICitiesRepository _citiesRepository;

        public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
        {
            _citiesRepository = citiesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => await _citiesRepository.GetAsync(pagination);

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination) => await _citiesRepository.GetTotalPagesAsync(pagination);
        public async Task<IEnumerable<City>> GetComboAsync(int stateId) => await _citiesRepository.GetComboAsync(stateId);

    }
}
