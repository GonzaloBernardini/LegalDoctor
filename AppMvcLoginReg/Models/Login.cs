using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage ="Debe Ingresar un Usuario")]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "Debe Ingresar una Contraseña")]
        public string Password { get; set; }
    }
}
