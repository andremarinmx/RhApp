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
            string fechaNacimiento,
            string estadoCivil,
            long numReloj,
            string fechaIngreso,
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
            string egresoEscuela,
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
        public ActionResult EditarEmpleado(
            int ID_EMPLEADO,
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
            string fechaNacimiento,
            string estadoCivil,
            long numReloj,
            string fechaIngreso,
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
            string egresoEscuela,
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
                Empleado emp = db.Empleadoes.Find(ID_EMPLEADO);
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
                db.SaveChanges();
                return RedirectToAction("VerEmpleados");
            }
        }
    }
}