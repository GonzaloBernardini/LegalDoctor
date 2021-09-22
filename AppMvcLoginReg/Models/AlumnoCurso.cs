using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Models
{
    public class AlumnoCurso
    {
        public int IdAlumno { get; set; }
        public int IdCurso { get; set; }
        public Alumno Alumno { get; set; }
        public Curso Curso { get; set; }

    }
}
