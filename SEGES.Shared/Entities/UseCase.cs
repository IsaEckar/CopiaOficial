using SEGES.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class UseCase : IEntityWithName, IEntityWithCreationDate
    {
        public int UseCaseID { get; set; }

        [Display(Name = "Caso de uso")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Usuario")]
        [MaxLength(4000, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string UseCaseDescription { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string? UseCaseFrequency { get; set; }

        [MaxLength(1500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string? UseCaseBussinessRule { get; set; }

        public string? UseCasePreondition { get; set; }
        public string? UseCasePostcondition { get; set; }
        public string? UseCaseExceptions { get; set; }
        public string? UseCaseWarnings { get; set; }
        public DateTime UseCaseCreationDate { get; set; }
        public DateTime UseCaseUpdateDate { get; set; }
        public DateTime CreationDate { get; set; }

        public int Requirement_Id { get; set; }
        public Requirement Requirement { get; set; }
    }
}