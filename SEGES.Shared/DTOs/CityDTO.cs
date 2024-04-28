using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.DTOs
{
    internal class CityDTO
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }

        public StateDTO State { get; set; }
    }
}
