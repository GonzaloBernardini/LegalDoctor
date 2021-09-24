using AppMvcLoginReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Controllers
{
    public class LoginController : Controller
    {
        private readonly SistemaCursosContext _context;

        public LoginController(SistemaCursosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid) // Validacion del form login
            {
                //Encriptamos password
                string passwordEncriptado = Encriptar(login.Password);
                //Consulta para verificar si usuario login,existe en la tabla usuario y el password sea igual al encriptado
                var loginUsuario = _context.Login.Where(p => p.Usuario == login.Usuario && p.Password == passwordEncriptado).FirstOrDefault();
                if (loginUsuario != null)
                {
                    //definimos la session usuario con el nombre usuario.
                    HttpContext.Session.SetString("usuario", loginUsuario.Usuario);
                    //Si no es nulo, osea si esta correcto, lo dirijo a index,home
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Si el login es incorrecto(usuario o contrase;a)
                    ViewData["ErrorLogin"] = "Los datos ingresados son incorrectos";
                    return View("Index");
                }
            }
            return View("Index");
        }

        public string Encriptar(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                                          //Compute retorna array de tipo byte //el string password se convierte a bytes con getbytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    //Lo recorremos para concatenarlo , los valores, y con x2 le decimos q convierta a hexadecimal los valores de byte
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                //finalmente lo retornamos , lo convertimos en string como cadena alfanumerica , es el resultado de la encriptacion
                return stringBuilder.ToString();
            }
        }


        public IActionResult Logout()
        {
            //Este metodo clear borra todas las variables de sesion que tengamos definidas
            HttpContext.Session.Clear();
            return View("Index");
        }

    }
}
