using Microsoft.AspNetCore.Mvc;
using SEGES.Shared.Entities;

namespace SEGES.Backend.Controllers
{
    public class ProjectStatusesController
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
