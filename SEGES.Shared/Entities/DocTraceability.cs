using SEGES.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    internal class DocTraceability : IEntityWithName, IEntityWithCreationDate
    {
        public int DocTraceabilityId { get; set; }

        [Display(Name = "Trazabilidad Documental")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }


        public string? Location { get; set; }

        public string? Observations { get; set; }

        [Display(Name = "Descripción tazabilidad Documental")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int Requirement_ID { get; set; }
        public Requirement Requirement { get; set; }

        public int? Source_Id { get; set; }
        public SourceDocTraceability Source { get; set; }

        public int? Type_Id { get; set; }
        public DocTraceabilityType? Type { get; set; }
    }
}
