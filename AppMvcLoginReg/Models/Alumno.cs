using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Models
{
    public class Alumno
    {
        [Key]
        
        public int IdAlumno { get; set; }

        
        public string Nombre { get; set; }

        
        public string Apellido { get; set; }

        
        public string Email { get; set; }

        [Display(Name = "Introduzca Nota 1")]
        public float? Nota1 { get; set; }

        [Display(Name = "Introduzca Nota 2")]
        public float? Nota2 { get; set; }

        [Display(Name = "Resultado Promedio Final")]
        public float? PromedioFinal { get; set; }

        
        [Display(Name = "Curso del Alumno")]
        public Curso CursoAsignado { get; set; }

        [Display(Name = " Introduzca Inasistencias")]
        public int? Inasistencias { get; set; }

        [Display(Name = "Seguimiento del alumno")]
        public string Seguimiento { get; set; }


        //Con esta propiedad muestro en vista alumno los cursos que le puedo asignar
        public List<AlumnoCurso> AlumnoCurso { get; set; }

    }
}
    
