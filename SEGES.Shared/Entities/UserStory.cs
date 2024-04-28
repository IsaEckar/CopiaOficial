using SEGES.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class UserStory : IEntityWithCreationDate, IEntityWithName
    {
        public int UserStoryId { get; set; }

        [Display(Name = "Historia de Usuario")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Descripción de Historia de Usuario")]
        [MaxLength(4000, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string UserStoryDescription { get; set; }

        public string? AcceptanceCriteria { get; set; }

        public DateTime CreationDate { get; set; }

        public int HUPriority_Id { get; set; }
        public HUPriority HUPriority { get; set; }

        public int HUPublicationStatus_Id { get; set; }
        public HUPublicationStatus HUPublicationStatus { get; set; }

        public int HUApprovalStatus_Id { get; set; }
        public HUApprovalStatus HUApprovalStatus { get; set; }

        public int HUStatus_Id { get; set; }
        public HUStatus HUStatus { get; set; }

        public int Requirement_Id { get; set; }
        public Requirement Requirement { get; set; }
    }
}