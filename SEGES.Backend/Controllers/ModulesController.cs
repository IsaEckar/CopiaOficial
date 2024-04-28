using Microsoft.AspNetCore.Mvc;

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
