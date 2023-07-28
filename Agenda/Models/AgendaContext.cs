using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Models;

namespace Agenda.Models
{
    public class AgendaContext : DbContext
    {
        // Se le pasa el objeto "opciones" que es de tipo DbContextOptions que a su vez se le pasa el tipo "TurnosContext"
        // con lo que se le pasan las opciones por default, pero basandose en las propiedades de nuestra clase TurnosContext
        // y con esto ": base(opciones)" heredamos las opciones base a la clase "TurnosContext"
        public AgendaContext(DbContextOptions<AgendaContext> opciones) : base(opciones)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turno { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad"); // Es el nombre ara la tabla, pero se puede modificar
                entidad.HasKey(e => e.IdEspecialidad);  // se especifica como clave primaria
                entidad.Property(e => e.Descripcion)  // se agrega el nuevo campo Descripcion
                    .IsRequired()   // indica que no se aceptan NULL
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");
                entidad.HasKey(p => p.IdPaciente);

                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medico");
                entidad.HasKey(m => m.IdMedico);

                entidad.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(m => m.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<Turno>(entidad =>
            {
                entidad.ToTable("Turno");
                entidad.HasKey(m => m.IdTurno);

                entidad.Property(m => m.IdPaciente)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.IdMedico)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.FechaHoraInicio)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.FechaHoraFin)
                .IsRequired()
                .IsUnicode(false);
            });

            // Se define un Indice Compuesto
            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            // Se define la relación Uno (Medico) a Muchos (Especialidad)
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
                .WithMany(p => p.MedicoEspecialidad) //
                .HasForeignKey(p => p.IdMedico);

            // Se establece la realación entre MedicoEspecialida y Especialidad
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
                .WithMany(p => p.MedicoEspecialidad) //
                .HasForeignKey(p => p.IdEspecialidad);

            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
                .WithMany(p => p.Turno)
                .HasForeignKey(p => p.IdPaciente);

            modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
                .WithMany(p => p.Turno)
                .HasForeignKey(p => p.IdMedico);
        }
    }
}
