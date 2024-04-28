using Microsoft.EntityFrameworkCore;
using SEGES.Backend.Repositories.Interfaces;
using SEGES.Backend.UnitsOfWork.Implementations;
using SEGES.Shared.Entities;
using SEGES.Shared.Responses;
using SEGES.Shared;

namespace SEGES.Backend.Repositories.Implementations
{
   
        public class HuAppruvalStatusRepository : GenericRepository<HUApprovalStatus>, IHuAppruvalStatusRepository
        {
            private readonly DataContext _context;
            public HuAppruvalStatusRepository(DataContext context) : base(context)
            {
                _context = context;
            }

            public override async Task<ActionResponse<HUApprovalStatus>> GetAsync(int id)
            {
                var status = await _context.HUApprovalStatuses.FindAsync(id);
                if (status == null)
                {
                    return new ActionResponse<HUApprovalStatus>
                    {
                        WasSuccess = false,
                        Message = "Estado no existe"
                    };
                }
                return new ActionResponse<HUApprovalStatus>
                {
                    WasSuccess = true,
                    Result = status
                };
            }

            public override async Task<ActionResponse<IEnumerable<HUApprovalStatus>>> GetAsync()
            {
                var statuses = await _context.HUApprovalStatuses.ToListAsync();
                return new ActionResponse<IEnumerable<HUApprovalStatus>>
                {
                    WasSuccess = true,
                    Result = statuses
                };
            }
        }
    }
