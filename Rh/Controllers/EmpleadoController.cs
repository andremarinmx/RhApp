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

        [HttpGet]
        public ActionResult AgregarExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarExcel(IEnumerable<Empleados> data)
        {
            using (AndreTestContext db = new AndreTestContext())
            {
                foreach (var item in data)
                {
                    if(item.NOMBRE == null)
                    {
                        //Saltar elementos ingresados auntomáticamente en excel
                    }
                    else
                    {
                        Empleado emp = new Empleado();
                        emp.NOMBRE = item.NOMBRE;
                        emp.APELLIDO_PATERNO = item.APELLIDO_PATERNO;
                        emp.APELLIDO_MATERNO = item.APELLIDO_MATERNO;
                        emp.IMSS = item.IMSS;
                        emp.RFC = item.RFC;
                        emp.CURP = item.CURP;
                        emp.SEXO = item.SEXO;
                        emp.DIRECCION = item.DIRECCION;
                        emp.COLONIA = item.COLONIA;
                        emp.CODIGO_POSTAL = item.CODIGO_POSTAL;
                        emp.ESTADO = item.ESTADO;
                        emp.NACIONALIDAD = item.NACIONALIDAD;
                        emp.MUNICIPIO = item.MUNICIPIO;
                        emp.TELEFONO = item.TELEFONO;
                        emp.CEL = item.CEL;
                        emp.FECHA_NACIMIENTO = item.FECHA_NACIMIENTO;
                        emp.ESTADO_CIVIL = item.ESTADO_CIVIL;
                        emp.NUM_RELOJ = item.NUM_RELOJ;
                        emp.FECHA_INGRESO = item.FECHA_INGRESO;
                        emp.COMPANIA = item.COMPANIA;
                        emp.PLANTA = item.PLANTA;
                        emp.DEPARTAMENTO = item.DEPARTAMENTO;
                        emp.AREA = item.AREA;
                        emp.SUPERVISOR = item.SUPERVISOR;
                        emp.TIPO = item.TIPO;
                        emp.CLASE = item.CLASE;
                        emp.PUESTO = item.PUESTO;
                        emp.HORARIO = item.HORARIO;
                        emp.LOCKER = item.LOCKER;
                        emp.FORMA_PAGO = item.FORMA_PAGO;
                        emp.BANCO = item.BANCO;
                        emp.NUMERO_TARJETA = item.NUMERO_TARJETA;
                        emp.SALARIO = item.SALARIO;
                        emp.NIVEL_ESCOLAR = item.NIVEL_ESCOLAR;
                        emp.NOMBRE_ESCUELA = item.NOMBRE_ESCUELA;
                        emp.DIRECCION_ESCUELA = item.DIRECCION_ESCUELA;
                        emp.EGRESO_ESCUELA = item.EGRESO_ESCUELA;
                        emp.EMERGENCIA_NOMBRE = item.EMERGENCIA_NOMBRE;
                        emp.EMERGENCIA_APELLIDO_PATERNO = item.EMERGENCIA_APELLIDO_PATERNO;
                        emp.EMERGENCIA_APELLIDO_MATERNO = item.EMERGENCIA_APELLIDO_MATERNO;
                        emp.EMERGENCIA_PARENTEZCO = item.EMERGENCIA_PARENTEZCO;
                        emp.EMERGENCIA_TELEFONO = item.EMERGENCIA_TELEFONO;
                        emp.EMERGENCIA_DIRECCION = item.EMERGENCIA_DIRECCION;
                        emp.FOTO = item.FOTO;
                        db.Empleadoes.Add(emp);
                        db.SaveChanges();
                    }
                }
                    return View();
            }
        }
    }

    public class Empleados
    {
        public long ID_EMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public long NUM_RELOJ { get; set; }
        public string FOTO { get; set; }
        public string FECHA_INGRESO { get; set; }
        public string FECHA_EGRESO { get; set; }
        public string COMPANIA { get; set; }
        public string PLANTA { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string SUPERVISOR { get; set; }
        public string AREA { get; set; }
        public string TIPO { get; set; }
        public string CLASE { get; set; }
        public string PUESTO { get; set; }
        public string TURNO { get; set; }
        public string HORARIO { get; set; }
        public long IMSS { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string SEXO { get; set; }
        public string GAFETE { get; set; }
        public string FORMA_PAGO { get; set; }
        public string BANCO { get; set; }
        public long NUMERO_TARJETA { get; set; }
        public long SALARIO { get; set; }
        public string DIRECCION { get; set; }
        public string COLONIA { get; set; }
        public string NACIONALIDAD { get; set; }
        public string ESTADO { get; set; }
        public string MUNICIPIO { get; set; }
        public long CODIGO_POSTAL { get; set; }
        public long TELEFONO { get; set; }
        public long CEL { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string LOCKER { get; set; }
        public string EMERGENCIA_NOMBRE { get; set; }
        public string EMERGENCIA_APELLIDO_PATERNO { get; set; }
        public string EMERGENCIA_APELLIDO_MATERNO { get; set; }
        public string EMERGENCIA_PARENTEZCO { get; set; }
        public long EMERGENCIA_TELEFONO { get; set; }
        public string EMERGENCIA_DIRECCION { get; set; }
        public string NIVEL_ESCOLAR { get; set; }
        public string NOMBRE_ESCUELA { get; set; }
        public string DIRECCION_ESCUELA { get; set; }
        public string EGRESO_ESCUELA { get; set; }
        public long ID_CURSO { get; set; }
    }
}