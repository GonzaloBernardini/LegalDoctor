using AppMvcLoginReg.DatosCrud;
using AppMvcLoginReg.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext contexto;

        public AlumnosController(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IActionResult Index()
        {
            IEnumerable<Alumnos> listaAlumnos = contexto.Alumnos;
            return View(listaAlumnos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Alumnos alum)
        {
            //agregamos la validacion antes del envio a base de datos
            if(ModelState.IsValid)
            {
                //Funcion agregar y guardar cambios!
                contexto.Alumnos.Add(alum);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Editar(int? id)
        {
            //lo buscamos por id
            Alumnos alum = contexto.Alumnos.Find(id);

            if (alum == null)
                return NotFound();
            //en caso de no encontrarlo retornar not found.

            return View(alum);

            
        }

        [HttpPost]
        public IActionResult Editar(Alumnos c)
        {
            if (ModelState.IsValid)
            {
                contexto.Alumnos.Update(c);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Borrar(int? id)
        {
            //Busco si el alumno existe segun el id
            Alumnos a = contexto.Alumnos.Find(id);

            //si existe no hay problema, sino devolvemos error
            if (a == null)
                return NotFound();

            //Borramos y guardamos cambios

            contexto.Alumnos.Remove(a);
            contexto.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
