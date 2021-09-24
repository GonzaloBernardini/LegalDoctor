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


        [Required(ErrorMessage="El campo nombre nombre   es obligatorio")]
        public string Nombre { get; set; }


        [Required(ErrorMessage="El campo  apellido es obligatorio")]
        public string Apellido { get; set; }

        [Display(Name ="Ingrese Email")]
        [Required(ErrorMessage="El campo email  es obligatorio")]
        [EmailAddress(ErrorMessage ="No es una direccion de email válida")]
        public string Email { get; set; }
        

        [Display(Name = "Introduzca Nota 1")]
        public float? Nota1 { get; set; }

        [Display(Name = "Introduzca Nota 2")]
        public float? Nota2 { get; set; }

        [Display(Name = "Resultado Promedio Final")]
        public float? PromedioFinal { get; set; }

           
        [Display(Name = "Inasistencias del Alumno")]
        public int? Inasistencias { get; set; }

        [Display(Name = "Seguimiento del alumno")]
        public string Seguimiento { get; set; }


        //Con esta propiedad muestro en vista alumno los cursos que le puedo asignar
        public List<AlumnoCurso> AlumnoCurso { get; set; }

    }
}
    
