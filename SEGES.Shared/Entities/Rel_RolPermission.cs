using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class Rel_RolPermission
    {
        public int RolePermissionId { get; set; }

        public int Role_ID { get; set; }
        public Role Role { get; set; }


        public int Permission_ID { get; set; }
        public Permission Permission { get; set; }
    }
}
