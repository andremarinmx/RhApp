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
        public List<Instructor> Instructores { get; set; }

        [HttpGet]
        public ActionResult CrearCurso()
        {
            return View(Instructores);
        }

        [HttpPost]
        public ActionResult CrearCurso(string nombre, int duracion, int calificacion, string tipo, string clasificacion, string areaTematica, string areaAplicacion, string objetivo, string modalidad, string comentarios, int instructor)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Curso cur = new Curso();
                Instructor inst = new Instructor() { ID_INSTRUCTOR = instructor};
                db.Instructors.Attach(inst);
                cur.NOMBRE = nombre;
                cur.DURACION = duracion;
                cur.CALIFICACION_MIN = calificacion;
                cur.TIPO_CURSO = tipo;
                cur.CLASIFICACION = clasificacion;
                cur.AREA_TEMATICA = areaTematica;
                cur.AREA_APLICACION = areaAplicacion;
                cur.OBJETIVO = objetivo;
                cur.MODALIDAD = modalidad;
                cur.COMENTARIOS = comentarios;
                cur.Instructor = inst;
                db.Cursoes.Add(cur);
                db.SaveChanges();
                Cursos = db.Cursoes.OrderBy(x => x.ID_CURSO).ToList();
                return RedirectToAction("VerCursos");
            }
        }

        [HttpGet]
        public ActionResult VerCursos()
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Cursos = db.Cursoes.OrderBy(x => x.ID_CURSO).ToList();
                return View(Cursos);
            }
        }

        [HttpGet]
        public ActionResult EliminarCurso(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Curso cur = db.Cursoes.Find(id);
                db.Cursoes.Remove(cur);
                db.SaveChanges();
                return RedirectToAction("VerCursos");
            }
        }

        [HttpGet]
        public ActionResult EditarCurso(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Curso cur = db.Cursoes.Find(id);
                return View(cur);
            }
        }

        [HttpPost]
        public ActionResult EditarCurso(Curso x, string tipo, string clasificacion, string areaTematica, string areaAplicacion, string objetivo, string modalidad)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Curso cur = db.Cursoes.Find(x.ID_CURSO);
                cur.NOMBRE = x.NOMBRE;
                cur.DURACION = x.DURACION;
                cur.CALIFICACION_MIN = x.CALIFICACION_MIN;
                cur.TIPO_CURSO = tipo;
                cur.CLASIFICACION = clasificacion;
                cur.AREA_TEMATICA = areaTematica;
                cur.AREA_APLICACION = areaAplicacion;
                cur.OBJETIVO = objetivo;
                cur.MODALIDAD = modalidad;
                cur.COMENTARIOS = x.COMENTARIOS;
                cur.Instructor = x.Instructor;
                db.SaveChanges();
                return RedirectToAction("VerCursos");
            }
        }
    }
}