﻿// <auto-generated />
using System;
using Agenda.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agenda.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20230728195654_Migracion_EntidadTurno")]
    partial class Migracion_EntidadTurno
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Agenda.Models.Especialidad", b =>
                {
                    b.Property<int>("IdEspecialidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("IdEspecialidad");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("Agenda.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime>("HorarioAtencionDesde")
                        .HasColumnType("datetime2")
                        .IsUnicode(false);

                    b.Property<DateTime>("HorarioAtencionHasta")
                        .HasColumnType("datetime2")
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("IdMedico");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Agenda.Models.MedicoEspecialidad", b =>
                {
                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdEspecialidad")
                        .HasColumnType("int");

                    b.HasKey("IdMedico", "IdEspecialidad");

                    b.HasIndex("IdEspecialidad");

                    b.ToTable("MedicoEspecialidad");
                });

            modelBuilder.Entity("Agenda.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("IdPaciente");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Agenda.Models.Turno", b =>
                {
                    b.Property<int>("IdTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaHoraFin")
                        .HasColumnType("datetime2")
                        .IsUnicode(false);

                    b.Property<DateTime>("FechaHoraInicio")
                        .HasColumnType("datetime2")
                        .IsUnicode(false);

                    b.Property<int>("IdMedico")
                        .HasColumnType("int")
                        .IsUnicode(false);

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int")
                        .IsUnicode(false);

                    b.HasKey("IdTurno");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("Agenda.Models.MedicoEspecialidad", b =>
                {
                    b.HasOne("Agenda.Models.Especialidad", "Especialidad")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agenda.Models.Medico", "Medico")
                        .WithMany("MedicoEspecialidad")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Agenda.Models.Turno", b =>
                {
                    b.HasOne("Agenda.Models.Medico", "Medico")
                        .WithMany("Turno")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Agenda.Models.Paciente", "Paciente")
                        .WithMany("Turno")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
