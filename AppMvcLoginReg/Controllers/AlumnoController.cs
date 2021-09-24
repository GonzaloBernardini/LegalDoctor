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
        public async Task<IActionResult>  Index()
        {                       //bd.tabla alumno.cree una lista y la muestre
            return View(await _context.Alumno.ToListAsync());
        }



        //GET: ALUMNO DETAILS
                                                 //acepta recibir id nulos
        public async Task<IActionResult>  Details(int? id)
        {
            if (id == null)
            {
                //si el id es nulo retorna no se encuentra(pag excepcion)
                return NotFound();
            }
            //creo variable y le asigno en bd.tabla alumno.donde.IdAlumno sea igual al id que recibo(vista detalle)
            var alumno = await _context.Alumno.Where(m => m.IdAlumno == id).Include(m => m.AlumnoCurso).ThenInclude(a => a.Curso).FirstOrDefaultAsync();

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
       
       public async Task<IActionResult>  Create([Bind("IdAlumno,Nombre,Apellido,Email,Nota1,Nota2,PromedioFinal,Inasistencias,Seguimiento")] Alumno alumno,int IdCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();

                var alumnoCurso = new AlumnoCurso();
                alumnoCurso.IdAlumno = alumno.IdAlumno;

                alumnoCurso.IdCurso = IdCurso;
                _context.Add(alumnoCurso);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        //GET ALUMNO/EDIT
        public async Task<IActionResult>  Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Consulta tipo select+InnerJoin para buscar en dos tablas distintas
            //Colocamos los datos del alumno a alumno y los registros de la tabla AlumnoCurso y si corresponde con IdAlumno
            var alumno = await _context.Alumno.Where(m => m.IdAlumno == id).Include(m => m.AlumnoCurso).FirstOrDefaultAsync();
            //var alumno = await _context.Alumno.FindAsync(id);



            if (alumno == null)
            {
                return NotFound();
            }
            

            ViewData["ListadoCursos"] = new SelectList(_context.Curso, "IdCurso", "NombreCurso", alumno.AlumnoCurso);


            return View(alumno);



        }


        //POST ALUMNO/EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult>  Edit(int id, [Bind("IdAlumno,Nombre,Apellido,Email,Nota1,Nota2,PromedioFinal,Inasistencias,Seguimiento,IdCurso")] Alumno alumno, int IdCurso)
        {
            if (id != alumno.IdAlumno)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                    var alumnoCurso = await _context.AlumnoCurso.FirstOrDefaultAsync(m => m.IdAlumno == id);

                     _context.Remove(alumnoCurso);
                     await _context.SaveChangesAsync();

                    alumnoCurso.IdCurso = IdCurso;
                    _context.Add(alumnoCurso);
                    await _context.SaveChangesAsync();



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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno.FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);

        }



        //POST ALUMNO/DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult>  Delete(int id)
        {

            var alumnoCurso = await _context.AlumnoCurso.FirstOrDefaultAsync(m => m.IdAlumno == id);

            _context.AlumnoCurso.Remove(alumnoCurso);

            var alumno = await _context.Alumno.FindAsync(id);
            _context.Alumno.Remove(alumno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool AlumnoExist(int id)
        {
            return _context.Alumno.Any(e => e.IdAlumno == id);
        }




    }
}
