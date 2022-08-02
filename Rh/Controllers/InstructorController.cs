using Rh.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class InstructorController : Controller
    {
        public List<Instructor> Instructores { get; set; }

        [HttpGet]
        public ActionResult CrearInstructores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearInstructores(string nombreCompleto, string compania, string stp, string tipo)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Instructor inst = new Instructor();
                inst.NOMBRE_COMPLETO = nombreCompleto;
                inst.COMPANIA = compania;
                inst.REGISTRO_STP = stp;
                inst.TIPO = tipo;
                db.Instructors.Add(inst);
                db.SaveChanges();
                Instructores = db.Instructors.OrderBy(x => x.ID_INSTRUCTOR).ToList();
                return RedirectToAction("VerInstructores");
            }
        }

        [HttpGet]
        public ActionResult VerInstructores()
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Instructores = db.Instructors.OrderBy(x => x.ID_INSTRUCTOR).ToList();
                return View(Instructores);
            }
        }

        [HttpGet]
        public ActionResult EliminarInstructor(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Instructor inst = db.Instructors.Find(id);
                db.Instructors.Remove(inst);
                db.SaveChanges();
                return RedirectToAction("VerInstructores");
            }
        }

        [HttpGet]
        public ActionResult EditarInstructor(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Instructor inst = db.Instructors.Find(id);
                return View(inst);
            }
        }

        [HttpPost]
        public ActionResult EditarInstructor(Instructor x, string tipo)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Instructor insta = db.Instructors.Find(x.ID_INSTRUCTOR);
                insta.NOMBRE_COMPLETO = x.NOMBRE_COMPLETO;
                insta.COMPANIA = x.COMPANIA;
                insta.REGISTRO_STP = x.REGISTRO_STP;
                insta.TIPO = tipo;
                //insta.TIPO = x.TIPO;
                db.SaveChanges();
                return RedirectToAction("VerInstructores");
            }
        }

    }
}