using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.DTOs
{
    public class StateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CountryDTO? Country { get; set; }
    }
}
