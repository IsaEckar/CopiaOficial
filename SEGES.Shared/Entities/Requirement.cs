using SEGES.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class Requirement : IEntityWithName, IEntityWithCreationDate
    {
        public int RequirementID { get; set; }

        [Display(Name = "Requerimiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Descripción Requerimiento")]
        [MaxLength(4000, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string RequirementDescription { get; set; }

        public DateTime CreationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Goal_ID { get; set; }
        public Goal Goal { get; set; }

        public ICollection<UseCase> UseCases { get; set; }

        public ICollection<UserStory> UserStories { get; set; }

        public ICollection<DocTraceability> DocTraceability { get; set; }
    }
}
