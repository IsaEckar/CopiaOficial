﻿using SEGES.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared.Entities
{
    public class SecundaryKPI : IEntityWithCreationDate
    {
        public int SecundaryKPI_Id { get; set; }

        [Display(Name = "KPI Secundario")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string SecundaryKPI_Name { get; set; }

        [Display(Name = "Descripción KPI Secundario")]
        [MaxLength(4000, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string SecundaryKPI_Description { get; set; }

        public string? SecundaryKPI_Formula { get; set; }

        public DateTime CreationDate { get; set; }

       // public int KPI_Id { get; set; }
        public KPI KPI { get; set; }
    }
}