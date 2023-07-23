using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class PacienteController : Controller
    {
        private readonly AgendaContext _context;

        public PacienteController(AgendaContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }
    }
}
