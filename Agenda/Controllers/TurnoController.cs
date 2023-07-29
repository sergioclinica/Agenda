﻿using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
            ViewData["IdPaciente"] = new SelectList((from paciente in _context.Paciente.ToList()
                                                   select new { IdPaciente = paciente.IdPaciente, NombreCompleto = paciente.Nombre + " " + 
                                                   paciente.Apellido }), "IdPaciente", "NombreCompleto");
            return View();
        }

        public JsonResult ObtenerTurnos(int IdMedico)
        {
            List<Turno> turnos = new List<Turno>();
            turnos = _context.Turno.Where(t => t.IdMedico == IdMedico).ToList();

            return Json(turnos);
        }

        [HttpPost]
        public JsonResult GrabarTurno(Turno turno)
        {
            var ok = false;

            try
            {
                _context.Turno.Add(turno);
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Excepción encontrada", e);
                //throw;
            }
            var jsonResult = new { ok = ok };

            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult EliminarTurno(int idTurno)
        {
            var ok = false;

            try
            {
                var turnoAEliminar = _context.Turno.Where(t => t.IdTurno == idTurno).FirstOrDefault();
                if(turnoAEliminar != null)
                {
                    _context.Turno.Remove(turnoAEliminar);
                    _context.SaveChanges();
                    ok = true;
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Excepción encontrada", e);
                //throw;
            }
            var jsonResult = new { ok = ok };

            return Json(jsonResult);
        }
    }
}
