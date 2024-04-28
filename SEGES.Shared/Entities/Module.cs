using SEGES.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class Module : IEntityWithCreationDate, IEntityWithName
    {
        public int ModuleId { get; set; }

        [Display(Name = "Módulo")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public string? ModuleDescription { get; set; } = null;



        public List<Permission> Permissions { get; set; }
        public DateTime CreationDate { get; set; }
        //public List<Module> Modules { get; } = null!;
    }
}
