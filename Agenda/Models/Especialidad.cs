using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [StringLength(200, ErrorMessage = "La descripción debe tener como máximo 200 caracteres")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string Descripcion { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}
