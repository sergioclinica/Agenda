using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico{ get; set; }

        [Required(ErrorMessage = "El dato Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El dato Apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El dato Dirección es obligatorio")]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El dato Teléfono es obligatorio")]
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El dato Emaiol es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo váido")]
        public string Email { get; set; }

        [Display(Name = "Horario desde")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm::tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }

        [Display(Name = "Horario hasta")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm::tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}
