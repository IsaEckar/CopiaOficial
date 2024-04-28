using Microsoft.AspNetCore.Mvc;
using SEGES.Shared.Entities;

namespace SEGES.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HUStatusController : GenericController<HUStatus>
    {
        public HUStatusController(IGenericUnitOfWork<HUStatus> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
