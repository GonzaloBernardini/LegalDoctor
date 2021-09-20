using AppMvcLoginReg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.DatosCrud
{
    public class ApplicationDbContext : DbContext
    {
        //creamos el constructor/llamamos al constructor base
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Creamos la tabla de nuestro modelo
        public DbSet<Alumnos> Alumnos { get; set; }

    }
}
