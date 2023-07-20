using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly AgendaContext _context;
        public EspecialidadController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Especialidad.ToList());
        }
    }
}
