using Microsoft.AspNetCore.Mvc;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.Entities;

namespace SEGES.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HUApprovalStatusController : GenericController<HUApprovalStatus>
    {
        private readonly IHuAppruvalStatusRepository _huAppruvalStatusRepository;
        public HUApprovalStatusController(IGenericUnitOfWork<HUApprovalStatus> unitOfWork, IHuAppruvalStatusRepository huAppruvalStatusRepository) : base(unitOfWork)
        {
            _huAppruvalStatusRepository = huAppruvalStatusRepository;
        }
        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var action = await _huAppruvalStatusRepository.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var action = await _huAppruvalStatusRepository.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }
    }
}
