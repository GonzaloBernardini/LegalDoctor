using AppMvcLoginReg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcLoginReg.Controllers
{
    public class CursoController : Controller
    {
        //Inicializo obj
        private readonly SistemaCursosContext _context;

        //Recibe como parametro la clase SistemaCursosContext para conectarse a la BD
        public CursoController(SistemaCursosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //Le paso a la vista el objeto context, accediendo a la tabla Curso
            //Con ToList devuelvo el total de registros de la entidad/Tabla Curso!
            return View(await _context.Curso.ToListAsync());
        }



        //El parametro recibido sera el id del curso que queremos editar
        //GET
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        //Metodo post, recibe del formulario los campos a rellenar en la tabla
        [HttpPost]
        public async Task<IActionResult> Editar(int id, [Bind("IdCurso,NombreCurso,NumeroDeClases,ValorCursos,FechaInicioCurso,FechaFinalizacionCurso")]Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(curso);

        }



        //Metodo  GET de tipo Borrar
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    //Accedemos al modelo curso, y buscara por idCurso con FirstOrDefault
        //    if (id == null)
        //    {
        //        NotFound();
        //    }
        //    var curso = await _context.Curso.FirstOrDefaultAsync(e => e.IdCurso == id);

        //    if (curso == null)
        //    {
        //        return NotFound();
        //    }

        //    return View();
        //}
       

        //Metodo POST de tipo Borrar
        //[HttpPost]
        public  async Task<IActionResult> Delete(int? id)
        {
            var curso = await _context.Curso.FindAsync(id);
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }


        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdCurso,NombreCurso,NumeroDeClases,ValorCursos,FechaInicioCurso,FechaFinalizacionCurso")] Curso curso )
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);

        }

    }
}
