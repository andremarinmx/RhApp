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
        public ActionResult CrearInstructores(int numReloj, string nombres, string apellidos)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Instructor inst = new Instructor();
                inst.NUM_RELOJ = numReloj;
                inst.NOMBRES = nombres;
                inst.APELLIDOS = apellidos;
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
        public ActionResult EditarInstructor(Instructor x)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Instructor insta = db.Instructors.Find(x.ID_INSTRUCTOR);
                insta.NUM_RELOJ = x.NUM_RELOJ;
                insta.NOMBRES = x.NOMBRES;
                insta.APELLIDOS = x.APELLIDOS;
                db.SaveChanges();
                return RedirectToAction("VerInstructores");
            }
        }

    }
}