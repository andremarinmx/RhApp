using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class EmployeeCourseController : Controller
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
                Employee_Course empCur = new Employee_Course();

                var empleado = db.Employees.Where(x => x.EmployeeID == numReloj).ToList();
                DateTime now = DateTime.Now;

                empCur.ID_CURSO = idCurso;
                empCur.ID_EMPLEADO = empleado[0].ID;
                empCur.FECHA = now;
                db.Employee_Course.Add(empCur);
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
                var empleado = db.Employees.Where(x => x.EmployeeID == numReloj).ToList();
                var idEmpleado = empleado[0].ID;
                var empleado_curso = db.Employee_Course.Where(x => x.ID_EMPLEADO == idEmpleado).ToList();
                return View(empleado_curso);
            }
        }

        [HttpGet]
        public ActionResult EliminarCursoEmpleado(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Employee_Course empCur = db.Employee_Course.Find(id);
                db.Employee_Course.Remove(empCur);
                db.SaveChanges();
                return RedirectToAction("BuscarCursosEmpleado");
            }
        }

        [HttpGet]
        public ActionResult Calificaciones()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AsignarCalificacion(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Employee_Course empCur = db.Employee_Course.Find(id);
                db.SaveChanges();
                return View(empCur);
            }
        }

        [HttpPost]
        public ActionResult AsignarCalificacion(Empleado_Curso x)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Employee_Course empCurso = db.Employee_Course.Find(x.ID_EMPLEADO_CURSO);
                empCurso.CALIFICACION = x.CALIFICACION;
                db.SaveChanges();
                return RedirectToAction("BuscarCursosEmpleado");
            }
        }
    }
}