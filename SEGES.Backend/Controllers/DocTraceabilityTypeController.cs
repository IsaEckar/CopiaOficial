using Microsoft.AspNetCore.Mvc;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.Entities;

namespace SEGES.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DocTraceabilityTypeController : GenericController<DocTraceabilityType>
    {
        private readonly IDocTraceabilityTypesRepository _docTraceabilityTypesRepository;
        public DocTraceabilityTypeController(IGenericUnitOfWork<DocTraceabilityType> unitOfWork, IDocTraceabilityTypesRepository docTraceabilityTypesRepository) : base(unitOfWork)
        {
            _docTraceabilityTypesRepository = docTraceabilityTypesRepository;
        }

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _docTraceabilityTypesRepository.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _docTraceabilityTypesRepository.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
