using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Usuario")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Correo Electrónico")]
        [MaxLength(254, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int City_Id { get; set; }
        public City City { get; set; } = null!;

        [Display(Name = "ID Rol")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public int Role_ID { get; set; }
        public Role Role { get; set; } = null!;

        public ICollection<Role> Roles { get; set; }
    }
}
