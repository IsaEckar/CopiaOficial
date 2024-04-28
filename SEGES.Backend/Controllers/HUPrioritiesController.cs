using Microsoft.AspNetCore.Mvc;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Interfaces;
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

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _repository.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
