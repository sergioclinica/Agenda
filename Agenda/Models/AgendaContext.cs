using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidad"); // Es el nombre ara la tabla, pero se puede modificar
                entidad.HasKey(e => e.IdEspecialidad);  // se especifica como clave primaria
                entidad.Property(e => e.Descripcion)  // se agrega el nuevo campo Descripcion
                    .IsRequired()   // indica que no se aceptan NULL
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
