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
        public ActionResult CrearEmpleado(
            string nombre,
            string apellidoPaterno,
            string apellidoMaterno,
            long imss,
            string rfc,
            string curp,
            string sexo,
            string direccion,
            string colonia,
            long cp,
            string nacionalidad,
            string estado,
            string municipio,
            long telefono,
            long cel,
            DateTime fechaNacimiento,
            string estadoCivil,
            long numReloj,
            DateTime fechaIngreso,
            string compania,
            string planta,
            string dept,
            string area,
            string supervisor,
            string tipoEmpleado,
            string clase,
            string puesto,
            string horario,
            string locker,
            string pago,
            string banco,
            long numTarjeta,
            float salario,
            string nivelEscolar,
            string nombreEscuela,
            string direccionEscuela,
            DateTime egresoEscuela,
            string emerNombre,
            string emerApellidoPaterno,
            string emerApellidoMaterno,
            string emerParentezco,
            long emerTelefono,
            string emerDireccion,
            string fotografia
        )
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado emp = new Empleado();
                emp.NOMBRE = nombre;
                emp.APELLIDO_PATERNO = apellidoPaterno;
                emp.APELLIDO_MATERNO = apellidoMaterno;
                emp.IMSS = imss;
                emp.RFC = rfc;
                emp.CURP = curp;
                emp.SEXO = sexo;
                emp.DIRECCION = direccion;
                emp.COLONIA = colonia;
                emp.CODIGO_POSTAL = cp;
                emp.ESTADO = estado;
                emp.NACIONALIDAD = nacionalidad;
                emp.MUNICIPIO = municipio;
                emp.TELEFONO = telefono;
                emp.CEL = cel;
                emp.FECHA_NACIMIENTO = fechaNacimiento;
                emp.ESTADO_CIVIL = estadoCivil;
                emp.NUM_RELOJ = numReloj;
                emp.FECHA_INGRESO = fechaIngreso;
                emp.COMPANIA = compania;
                emp.PLANTA = planta;
                emp.DEPARTAMENTO = dept;
                emp.AREA = area;
                emp.SUPERVISOR = supervisor;
                emp.TIPO = tipoEmpleado;
                emp.CLASE = clase;
                emp.PUESTO = puesto;
                emp.HORARIO = horario;
                emp.LOCKER = locker;
                emp.FORMA_PAGO = pago;
                emp.BANCO = banco;
                emp.NUMERO_TARJETA = numTarjeta;
                emp.SALARIO = salario;
                emp.NIVEL_ESCOLAR = nivelEscolar;
                emp.NOMBRE_ESCUELA = nombreEscuela;
                emp.DIRECCION_ESCUELA = direccionEscuela;
                emp.EGRESO_ESCUELA = egresoEscuela;
                emp.EMERGENCIA_NOMBRE = emerNombre;
                emp.EMERGENCIA_APELLIDO_PATERNO = emerApellidoPaterno;
                emp.EMERGENCIA_APELLIDO_MATERNO = emerApellidoMaterno;
                emp.EMERGENCIA_PARENTEZCO = emerParentezco;
                emp.EMERGENCIA_TELEFONO = emerTelefono;
                emp.EMERGENCIA_DIRECCION = emerDireccion;
                emp.FOTO = fotografia;
                db.Empleadoes.Add(emp);
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

        [HttpGet]
        public ActionResult EliminarEmpleado(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado emp = db.Empleadoes.Find(id);
                db.Empleadoes.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("VerEmpleados");
            }
        }

        [HttpGet]
        public ActionResult EditarEmpleado(int id)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado emp = db.Empleadoes.Find(id);
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult EditarEmpleado(Empleado x)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                Empleado emp = db.Empleadoes.Find(x.ID_EMPLEADO);
                emp.NOMBRE = x.NOMBRE;
                emp.APELLIDO_PATERNO = x.APELLIDO_PATERNO;
                emp.APELLIDO_MATERNO = x.APELLIDO_MATERNO;
                emp.IMSS = x.IMSS;
                emp.RFC = x.RFC;
                emp.CURP = x.CURP;
                emp.SEXO = x.SEXO;
                emp.DIRECCION = x.DIRECCION;
                emp.COLONIA = x.COLONIA;
                emp.CODIGO_POSTAL = x.CODIGO_POSTAL;
                emp.ESTADO = x.ESTADO;
                emp.NACIONALIDAD = x.NACIONALIDAD;
                emp.MUNICIPIO = x.MUNICIPIO;
                emp.TELEFONO = x.TELEFONO;
                emp.CEL = x.CEL;
                emp.FECHA_NACIMIENTO = x.FECHA_NACIMIENTO;
                emp.ESTADO_CIVIL = x.ESTADO_CIVIL;
                emp.NUM_RELOJ = x.NUM_RELOJ;
                emp.FECHA_INGRESO = x.FECHA_INGRESO;
                emp.COMPANIA = x.COMPANIA;
                emp.PLANTA = x.PLANTA;
                emp.DEPARTAMENTO = x.DEPARTAMENTO;
                emp.AREA = x.AREA;
                emp.SUPERVISOR = x.SUPERVISOR;
                emp.TIPO = x.TIPO;
                emp.CLASE = x.CLASE;
                emp.PUESTO = x.PUESTO;
                emp.HORARIO = x.HORARIO;
                emp.LOCKER = x.LOCKER;
                emp.FORMA_PAGO = x.FORMA_PAGO;
                emp.BANCO = x.BANCO;
                emp.NUMERO_TARJETA = x.NUMERO_TARJETA;
                emp.SALARIO = x.SALARIO;
                emp.NIVEL_ESCOLAR = x.NIVEL_ESCOLAR;
                emp.NOMBRE_ESCUELA = x.NOMBRE_ESCUELA;
                emp.DIRECCION_ESCUELA = x.DIRECCION_ESCUELA;
                emp.EGRESO_ESCUELA = x.EGRESO_ESCUELA;
                emp.EMERGENCIA_NOMBRE = x.EMERGENCIA_NOMBRE;
                emp.EMERGENCIA_APELLIDO_PATERNO = x.EMERGENCIA_APELLIDO_PATERNO;
                emp.EMERGENCIA_APELLIDO_MATERNO = x.EMERGENCIA_APELLIDO_MATERNO;
                emp.EMERGENCIA_PARENTEZCO = x.EMERGENCIA_PARENTEZCO;
                emp.EMERGENCIA_TELEFONO = x.EMERGENCIA_TELEFONO;
                emp.EMERGENCIA_DIRECCION = x.EMERGENCIA_DIRECCION;
                db.SaveChanges();
                return RedirectToAction("VerEmpleados");
            }
        }
    }
}