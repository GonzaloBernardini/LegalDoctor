using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }



        [Display(Name = "Nombre del Curso")]
        public string NombreCurso { get; set; }

        
        [Display(Name = "Numero de Clases")]
        public int NumeroDeClases { get; set; }

        
        [Display(Name = "Valor del Curso")]
        public float ValorCursos { get; set; }


        [Display(Name = "Fecha de Inicio del Curso")]
        public DateTime FechaInicioCurso { get; set; }

        [Display(Name = "Fecha de Finalización del Curso")]
        public DateTime FechaFinalizacionCurso { get; set; }


        //Con esta propiedad puedo hacer una lista de los cursos para mostrarlos y asignarlos a alumnos
        public List<AlumnoCurso> AlumnoCurso { get; set; }

    }
}
