using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class EmpleadoController : Controller
    {
        public List<Empleado> Empleado { get; set; }

        [HttpGet]
        public ActionResult CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearEmpleado(Empleado y)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado emp = new Empleado();
                emp.NOMBRE = y.NOMBRE;
                db.SaveChanges();
                Empleado = db.Empleadoes.OrderBy(x => x.ID_EMPLEADO).ToList();
                return RedirectToAction("VerEmpleados");
            }
        }

        [HttpGet]
        public ActionResult VerEmpleados()
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado = db.Empleadoes.OrderBy(x => x.ID_EMPLEADO).ToList();
                return View(Empleado);
            }
        }
    }
}