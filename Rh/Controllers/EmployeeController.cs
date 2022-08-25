using Rh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rh.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult CrearEmpleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearEmpleado(
            int numReloj,
            string nombre,
            string apellidoPaterno,
            string apellidoMaterno,
            string imss,
            string rfc,
            string curp,
            string JobCode,
            string JobProfile,
            string SupervisoryOrganization,
            int SupervisoryOrganizationID,
            string ManagerName,
            int ManagerID,
            int LocationCode,
            string Location,
            string HireDate,
            float JCICFBasePayDaily,
            string JobCategory,
            string WorkShift,
            string ShiftMexico,
            string JobTitle
        )
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Employee emp = new Employee();
                emp.EmployeeID = numReloj;
                emp.LegalNameLastName = apellidoPaterno;
                emp.LegalNameSecondaryLastName = apellidoMaterno;
                emp.LegalNameFirstName = nombre;
                emp.FullLegalName = nombre + " " + apellidoPaterno + " " + apellidoMaterno;
                emp.JobCode = JobCode;
                emp.JobProfile = JobProfile;
                emp.JobTitle = JobTitle;
                emp.SupervisoryOrganization = SupervisoryOrganization;
                emp.SupervisoryOrganizationID = SupervisoryOrganizationID;
                emp.ManagerID = ManagerID;
                emp.ManagerName = ManagerName;
                emp.LocationCode = LocationCode;
                emp.Location = Location;
                emp.HireDate = HireDate;
                emp.JCICFBasePayDaily = JCICFBasePayDaily;
                emp.MexicoRFC = rfc;
                emp.MexicoCURP = curp;
                emp.MexicoIMSS = imss;
                emp.JobCategory = JobCategory;
                emp.WorkShift = WorkShift;
                emp.ShiftMexico = ShiftMexico;
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("VerEmpleadosMin");
            }
        }

        [HttpGet]
        public ActionResult VerEmpleadosMin()
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                var Empleado = db.Employees.OrderBy(x => x.EmployeeID).ToList();
                return View(Empleado);
            }
        }

        [HttpGet]
        public ActionResult VerEmpleadosMax()
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                var Empleado = db.Employees.OrderBy(x => x.EmployeeID).ToList();
                return View(Empleado);
            }
        }

        [HttpGet]
        public ActionResult EliminarEmpleado(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("VerEmpleadosMin");
            }
        }

        [HttpGet]
        public ActionResult EditarEmpleado(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Employee emp = db.Employees.Find(id);
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult EditarEmpleado(Employee x)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Employee emp = db.Employees.Find(x.ID);
                emp.EmployeeID = x.EmployeeID;
                emp.FullLegalName = x.FullLegalName;
                emp.LegalNameLastName = x.LegalNameLastName;
                emp.LegalNameSecondaryLastName = x.LegalNameSecondaryLastName;
                emp.LegalNameFirstName = x.LegalNameFirstName;
                emp.JobCode = x.JobCode;
                emp.JobProfile = x.JobProfile;
                emp.JobTitle = x.JobTitle;
                emp.SupervisoryOrganization = x.SupervisoryOrganization;
                emp.SupervisoryOrganizationID = x.SupervisoryOrganizationID;
                emp.ManagerID = x.ManagerID;
                emp.ManagerName = x.ManagerName;
                emp.LocationCode = x.LocationCode;
                emp.Location = x.Location;
                emp.HireDate = x.HireDate;
                emp.JCICFBasePayDaily = x.JCICFBasePayDaily;
                emp.MexicoRFC = x.MexicoRFC;
                emp.MexicoCURP = x.MexicoCURP;
                emp.MexicoIMSS = x.MexicoIMSS;
                emp.JobCategory = x.JobCategory;
                emp.WorkShift = x.WorkShift;
                emp.ShiftMexico = x.ShiftMexico;
                db.SaveChanges();
                return RedirectToAction("VerEmpleadosMin");
            }
        }

        [HttpGet]
        public ActionResult AgregarExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarExcel(IEnumerable<Employees> data)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                foreach (var item in data)
                {
                    int EmployeeID = item.EmployeeID;
                    var existe = db.Employees.Where(x => x.EmployeeID == EmployeeID).Count();
                    if (item.FullLegalName != null && existe == 0)
                    {
                        Employee emp = new Employee();
                        emp.EmployeeID = item.EmployeeID;
                        emp.FullLegalName = item.FullLegalName;
                        emp.LegalNameLastName = item.LegalNameLastName;
                        emp.LegalNameSecondaryLastName = item.LegalNameSecondaryLastName;
                        emp.LegalNameFirstName = item.LegalNameFirstName;
                        emp.JobCode = item.JobCode;
                        emp.JobProfile = item.JobProfile;
                        emp.JobTitle = item.JobTitle;
                        emp.SupervisoryOrganization = item.SupervisoryOrganization;
                        emp.SupervisoryOrganizationID = item.SupervisoryOrganizationID;
                        emp.ManagerID = item.ManagerID;
                        emp.ManagerName = item.ManagerName;
                        emp.LocationCode = item.LocationCode;
                        emp.Location = item.Location;
                        emp.HireDate = item.HireDate;
                        emp.JCICFBasePayDaily = item.JCICFBasePayDaily;
                        emp.MexicoRFC = item.MexicoRFC;
                        emp.MexicoCURP = item.MexicoCURP;
                        emp.MexicoIMSS = item.MexicoIMSS;
                        emp.JobCategory = item.JobCategory;
                        emp.WorkShift = item.WorkShift;
                        emp.ShiftMexico = item.ShiftMexico;
                        db.Employees.Add(emp);
                        db.SaveChanges();
                    }
                }
                return View();
            }
        }
    }
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FullLegalName { get; set; }
        public string LegalNameLastName { get; set; }
        public string LegalNameSecondaryLastName { get; set; }
        public string LegalNameFirstName { get; set; }
        public string JobCode { get; set; }
        public string JobProfile { get; set; }
        public string JobTitle { get; set; }
        public int SupervisoryOrganizationID { get; set; }
        public string SupervisoryOrganization { get; set; }
        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public int LocationCode { get; set; }
        public string Location { get; set; }
        public string HireDate { get; set; }
        public int JCICFBasePayDaily { get; set; }
        public string MexicoRFC { get; set; }
        public string MexicoCURP { get; set; }
        public string MexicoIMSS { get; set; }
        public string JobCategory { get; set; }
        public string WorkShift { get; set; }
        public string ShiftMexico { get; set; }
    }
}