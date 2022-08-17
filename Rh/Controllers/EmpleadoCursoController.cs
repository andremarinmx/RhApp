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
        List<Empleado> empleado;
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
                Empleado emp = new Empleado();

                empleado = db.Empleadoes.Where(x => x.NUM_RELOJ == numReloj).ToList();

                foreach (var item in empleado)
                {
                    empCur.ID_CURSO = idCurso;
                    empCur.ID_EMPLEADO = item.ID_EMPLEADO;
                }
                db.Empleado_Curso.Add(empCur);
                db.SaveChanges();
                return View();
            }
        }
    }
}