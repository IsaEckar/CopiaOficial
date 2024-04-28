using Microsoft.AspNetCore.Mvc;
using SEGES.Backend.UnitsOfWork.Interfaces;
using SEGES.Shared.Entities;

namespace SEGES.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ModulesController : GenericController<Module>
    {
        public ModulesController(IGenericUnitOfWork<Module> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
