using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        
        [Required(ErrorMessage = "El dato  es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máximas es de 50 caracterres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El dato  es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud máximas es de 50 caracterres")]
        public  string Apellido { get; set; }

        [Required(ErrorMessage = "El dato  es obligatorio")]
        [DisplayName("Dirección")]
        [StringLength(50, ErrorMessage = "La longitud máximas es de 250 caracterres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El dato  es obligatorio")]
        [DisplayName("Teléfno")]
        public string Telefono { get; set;}

        [Required(ErrorMessage = "El dato  es obligatorio")]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "La longitud máximas es de 100 caracterres")]
        public string Email { get; set; }
    }
}
