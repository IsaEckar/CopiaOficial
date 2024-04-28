using Microsoft.AspNetCore.Mvc;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.Entities;

namespace SEGES.Backend.Controllers
{
    
        [ApiController]
        [Route("api/[Controller]")]
        public class ProjectStatusesController : GenericController<ProjectStatus>
        {
            public ProjectStatusesController(IGenericUnitOfWork<ProjectStatus> unitOfWork) : base(unitOfWork)
            {
            }
        }
    
}
