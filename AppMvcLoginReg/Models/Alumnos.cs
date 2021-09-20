using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Models
{
    public class Alumnos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [Display(Name = "Nombre del Alumno")]
        public string NombreCompleto { get; set; }


        [Required(ErrorMessage = "El campo Curso Actual es obligatorio")]
        [Display(Name = "Curso Actual")]
        public string CursoActual { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }


    }
}
