using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Agenda.Controllers
{
    public class TurnoController : Controller
    {
        private readonly AgendaContext _context;
        private IConfiguration _configuration;

        public TurnoController(AgendaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList((from medico in _context.Medico.ToList() 
                                                   select new { IdMedico = medico.IdMedico, NombreCompleto = medico.Nombre + " " + 
                                                   medico.Apellido }), "IdMedico", "NombreCompleto");
            ViewData["IdPeciente"] = new SelectList((from paciente in _context.Paciente.ToList()
                                                   select new { IdPaciente = paciente.IdPaciente, NombreCompleto = paciente.Nombre + " " + 
                                                   paciente.Apellido }), "IdPaciente", "NombreCompleto");
            return View();
        }
    }
}
