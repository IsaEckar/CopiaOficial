using Microsoft.EntityFrameworkCore;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Implementations;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using SEGES.Shared;
using static SEGES.Backend.Repositories.Implementations.DocTraceabilityTypesRepository;

namespace SEGES.Backend.Repositories.Implementations
{
    
        public class DocTraceabilityTypesRepository : GenericRepository<DocTraceabilityType>, IDocTraceabilityTypesRepository
        {
            private readonly DataContext _context;
            public DocTraceabilityTypesRepository(DataContext context) : base(context)
            {
                _context = context;
            }

            public override async Task<ActionResponse<DocTraceabilityType>> GetAsync(int id)
            {
                var type = await _context.DocTraceabilityTypes.FindAsync(id);
                if (type == null)
                {
                    return new ActionResponse<DocTraceabilityType>
                    {
                        WasSuccess = false,
                        Message = "Tipo no existe"
                    };
                }
                return new ActionResponse<DocTraceabilityType>
                {
                    WasSuccess = true,
                    Result = type
                };
            }

            public override async Task<ActionResponse<IEnumerable<DocTraceabilityType>>> GetAsync()
            {
                var types = await _context.DocTraceabilityTypes.ToListAsync();
                return new ActionResponse<IEnumerable<DocTraceabilityType>>
                {
                    WasSuccess = true,
                    Result = types
                };
            }

        }
    
}
