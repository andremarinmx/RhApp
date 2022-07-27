using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class CursoController : Controller
    {
        public List<Curso> Cursos { get; set; }

        [HttpGet]
        public ActionResult CrearCurso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearInstructores(string nombre, int duracion, int calificacion, string tipo, string clasificacion, string areaTematica, string areaAplicacion, string objetivo, string modalidad, string comentarios, int instructor)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Curso cur = new Curso();
                db.Cursoes.Add(cur);
                db.SaveChanges();
                Cursos = db.Cursoes.OrderBy(x => x.ID_CURSO).ToList();
                return RedirectToAction("VerCursos");
            }
        }
    }
}