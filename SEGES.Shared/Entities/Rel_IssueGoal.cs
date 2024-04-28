using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class Rel_IssueGoal
    {
        public int Rel_IssueGoalId { get; set; }

        public int Issue_ID { get; set; }
        public Issue Issue { get; set; }

        public int Goal_ID { get; set; }
        public Goal Goal { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
