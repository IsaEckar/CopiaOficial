using Microsoft.AspNetCore.Mvc;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.DTOs;
using SEGES.Shared.Entities;

namespace SEGES.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HUPrioritiesController : GenericController<HUPriority>
    {
        private readonly IHUPrioritiesRepository _repository;
        public HUPrioritiesController(IGenericUnitOfWork<HUPriority> unitOfWork, IHUPrioritiesRepository repository) : base(unitOfWork)
        {
            _repository = repository;
        }
        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _repository.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
        {
            var response = await _repository.GetAsync(pagination);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _repository.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _repository.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

    }
}
