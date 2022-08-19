using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class EmpleadoCursoController : Controller
    {
        [HttpGet]
        public ActionResult AsignarCursos()
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AsignarCursos(int idCurso, int numReloj)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado_Curso empCur = new Empleado_Curso();

                var empleado = db.Empleadoes.Where(x => x.NUM_RELOJ == numReloj).ToList();
                empCur.ID_CURSO = idCurso;
                empCur.ID_EMPLEADO = empleado[0].ID_EMPLEADO;
                db.Empleado_Curso.Add(empCur);
                db.SaveChanges();
                return View();
            }
        }

        [HttpGet]
        public ActionResult BuscarCursosEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerCursosEmpleado(int numReloj)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                var empleado = db.Empleadoes.Where(x => x.NUM_RELOJ == numReloj).ToList();
                long idEmpleado = empleado[0].ID_EMPLEADO;
                var empleado_curso = db.Empleado_Curso.Where(x => x.ID_EMPLEADO == idEmpleado).ToList();
                return View(empleado_curso);
            }
        }

        [HttpGet]
        public ActionResult EliminarCursoEmpleado(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado_Curso empCur = db.Empleado_Curso.Find(id);
                db.Empleado_Curso.Remove(empCur);
                db.SaveChanges();
                return RedirectToAction("BuscarCursosEmpleado");
            }
        }
    }
}