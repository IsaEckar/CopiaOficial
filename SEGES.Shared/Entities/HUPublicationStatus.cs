using SEGES.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SEGES.Shared.Entities
{
    public class HUPublicationStatus : IEntityWithName
    {
        public int HUPublicationStatusId { get; set; }

        [Display(Name = "Estado de Publicación de HU")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }

    }
}
