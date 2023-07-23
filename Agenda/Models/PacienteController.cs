﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
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

        public async Task<IActionResult> Details(int? id) {
            if(id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);

            if(paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPatch]
        [ValidateAntiForgeryToken] // Gatantiza que el método se ejecute desde el formulario de la palicación
        public async Task<IActionResult> Create([Bind("IdPaciente, Nombre, Apellido, Direccion, Telefono, Email")] Paciente paciente)
        {
            if(ModelState.IsValid)
            {
                _context.Paciente.Add(paciente);
                await _context.SaveChangesAsync();  
                return RedirectToAction(nameof(Index)); 
            }

            return View(paciente);
        }
    }
}
