using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Models
{
    public class SistemaCursosContext : DbContext
    {

        public SistemaCursosContext(DbContextOptions<SistemaCursosContext>opciones)
            : base(opciones)
        {

        }


        //Entidad Tabla tipo Curso del model Curso
        //Curso va a ser el nombre de mi tabla en sqlserver!
        public DbSet<Curso> Curso { get; set; }

        public DbSet<Alumno> Alumno { get; set; }

        public DbSet<AlumnoCurso> AlumnoCurso { get; set; }

        //Metodo sobreescrito
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(entidad =>
            {

                entidad.ToTable("Curso");
                entidad.HasKey(e => e.IdCurso);
                entidad.Property(e => e.NombreCurso).IsRequired().HasMaxLength(200).IsUnicode(false);
                entidad.Property(e => e.FechaInicioCurso).IsRequired().IsUnicode(false);
                entidad.Property(e => e.FechaFinalizacionCurso).IsRequired().IsUnicode(false);
                entidad.Property(e => e.ValorCursos).IsRequired().IsUnicode(false);
                entidad.Property(e => e.NumeroDeClases).IsRequired().IsUnicode(false);

            });
            modelBuilder.Entity<Alumno>(entidad => 
            {
                entidad.ToTable("Alumno");
                entidad.HasKey(m => m.IdAlumno);
                entidad.Property(m => m.Nombre).IsRequired().HasMaxLength(50).IsUnicode(false);
                entidad.Property(m => m.Apellido).IsRequired().HasMaxLength(50).IsUnicode(false);
                entidad.Property(m => m.Email).IsRequired().HasMaxLength(100).IsUnicode(false);
                entidad.Property(m => m.Seguimiento).HasMaxLength(300).IsUnicode(false);
                
            });


            modelBuilder.Entity<AlumnoCurso>().HasKey(x => new { x.IdAlumno, x.IdCurso });

            //CLAVE FORANEA ENTRE ALUMNO CURSO Y ALUMNO
            modelBuilder.Entity<AlumnoCurso>().HasOne(x => x.Alumno).WithMany(p => p.AlumnoCurso).HasForeignKey(p => p.IdAlumno);


            //CLAVE FORANEA ENTRE ALUMNO CURSO Y CURSO
            modelBuilder.Entity<AlumnoCurso>().HasOne(x => x.Curso).WithMany(p => p.AlumnoCurso).HasForeignKey(p => p.IdCurso);


        }

    }
}
