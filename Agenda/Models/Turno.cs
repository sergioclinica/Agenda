using System;

namespace Agenda.Models
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}
