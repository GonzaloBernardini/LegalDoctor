using AppMvcLoginReg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly SistemaCursosContext _context;

        public AlumnoController(SistemaCursosContext context)
        {
            _context = context;
        }


        //GET : ALUMNO
        public IActionResult Index()
        {
            return View(_context.Alumno.ToList());
        }

        //GET: ALUMNO DETAILS

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = _context.Alumno
                .Where(m => m.IdAlumno == id).Include(m => m.AlumnoCurso).ThenInclude(a => a.Curso).FirstOrDefault();

            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);

        }



        //GET: ALUMNO/CREATE
        public IActionResult Create()
        {
            ViewData["ListadoCursos"] = new SelectList(_context.Curso, "IdCurso", "NombreCurso");
            return View();
        }



        //POST: ALUMNO/CREATE

       [HttpPost]
       [ValidateAntiForgeryToken]

       public IActionResult Create([Bind("IdAlumno,Nombre,Apellido,Email,Nota1,Nota2,PromedioFinal,CursoAsignado,Inasistencias,Seguimiento")] Alumno alumno,int IdCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                _context.SaveChanges();

                var alumnoCurso = new AlumnoCurso();
                alumnoCurso.IdAlumno = alumno.IdAlumno;

                alumnoCurso.IdCurso = IdCurso;
                _context.Add(alumnoCurso);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        //GET ALUMNO/EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Consulta tipo select+InnerJoin para buscar en dos tablas distintas
            var alumno = _context.Alumno.Where(m => m.IdAlumno == id).Include(m => m.AlumnoCurso).FirstOrDefault();
            if (alumno == null)
            {
                return NotFound();
            }

            ViewData["ListadoCursos"] = new SelectList(_context.Curso, "IdCurso", "NombreCurso", alumno.AlumnoCurso[0].IdCurso);


            return View(alumno);



        }


        //POST ALUMNO/EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, [Bind("IdAlumno,Nombre,Apellido,Email,Nota1,Nota2,PromedioFinal,CursoAsignado,Inasistencias,Seguimiento")] Alumno alumno, int IdCurso)
        {
            if(id != alumno.IdAlumno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    _context.SaveChanges();
                    var alumnoCurso = _context.AlumnoCurso.FirstOrDefault(m => m.IdAlumno == id);

                    _context.Remove(alumnoCurso);
                    _context.SaveChanges();

                    alumnoCurso.IdCurso = IdCurso;
                    _context.Add(alumnoCurso);
                    _context.SaveChanges();



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExist(alumno.IdAlumno))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }


        //GET: ALUMNO/DELETE
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var alumno = _context.Alumno.FirstOrDefault(m => m.IdAlumno == id);
        //    if (alumno == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(alumno);

        //}



        //POST ALUMNO/DELETE
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        public IActionResult Delete(int? id)
        {

            var alumnoCurso = _context.AlumnoCurso.FirstOrDefault(m => m.IdAlumno == id);

            _context.AlumnoCurso.Remove(alumnoCurso);

            var alumno = _context.Alumno.Find(id);
            _context.Alumno.Remove(alumno);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        private bool AlumnoExist(int id)
        {
            return _context.Alumno.Any(e => e.IdAlumno == id);
        }




    }
}
