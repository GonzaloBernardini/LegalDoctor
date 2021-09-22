﻿// <auto-generated />
using System;
using AppMvcLoginReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppMvcLoginReg.Migrations.SistemaCursos
{
    [DbContext(typeof(SistemaCursosContext))]
    partial class SistemaCursosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppMvcLoginReg.Models.Alumno", b =>
                {
                    b.Property<int>("IdAlumno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("CursoAsignadoIdCurso")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Inasistencias")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<float?>("Nota1")
                        .HasColumnType("real");

                    b.Property<float?>("Nota2")
                        .HasColumnType("real");

                    b.Property<float?>("PromedioFinal")
                        .HasColumnType("real");

                    b.Property<string>("Seguimiento")
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.HasKey("IdAlumno");

                    b.HasIndex("CursoAsignadoIdCurso");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("AppMvcLoginReg.Models.AlumnoCurso", b =>
                {
                    b.Property<int>("IdAlumno")
                        .HasColumnType("int");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.HasKey("IdAlumno", "IdCurso");

                    b.HasIndex("IdCurso");

                    b.ToTable("AlumnoCurso");
                });

            modelBuilder.Entity("AppMvcLoginReg.Models.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFinalizacionCurso")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioCurso")
                        .IsUnicode(false)
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCurso")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("NumeroDeClases")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<float>("ValorCursos")
                        .IsUnicode(false)
                        .HasColumnType("real");

                    b.HasKey("IdCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("AppMvcLoginReg.Models.Alumno", b =>
                {
                    b.HasOne("AppMvcLoginReg.Models.Curso", "CursoAsignado")
                        .WithMany()
                        .HasForeignKey("CursoAsignadoIdCurso");

                    b.Navigation("CursoAsignado");
                });

            modelBuilder.Entity("AppMvcLoginReg.Models.AlumnoCurso", b =>
                {
                    b.HasOne("AppMvcLoginReg.Models.Alumno", "Alumno")
                        .WithMany("AlumnoCurso")
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppMvcLoginReg.Models.Curso", "Curso")
                        .WithMany("AlumnoCurso")
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("AppMvcLoginReg.Models.Alumno", b =>
                {
                    b.Navigation("AlumnoCurso");
                });

            modelBuilder.Entity("AppMvcLoginReg.Models.Curso", b =>
                {
                    b.Navigation("AlumnoCurso");
                });
#pragma warning restore 612, 618
        }
    }
}
