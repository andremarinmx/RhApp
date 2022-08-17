CREATE TABLE Instructor(
	ID_INSTRUCTOR BIGINT PRIMARY KEY IDENTITY(1,1),
	NOMBRE_COMPLETO VARCHAR (300),
	TIPO VARCHAR(30),
	COMPANIA VARCHAR(60),
	REGISTRO_STP VARCHAR(300)
);

CREATE TABLE Curso (
	ID_CURSO BIGINT PRIMARY KEY IDENTITY (1,1),
	NOMBRE VARCHAR(60),
	DURACION BIGINT,
	CALIFICACION_MIN BIGINT,
	TIPO_CURSO VARCHAR(30),
	CLASIFICACION VARCHAR(300),
	AREA_TEMATICA VARCHAR(300),
	AREA_APLICACION VARCHAR(60),
	OBJETIVO VARCHAR(300),
	MODALIDAD VARCHAR(30),
	COMENTARIOS VARCHAR(600),
	ID_INSTRUCTOR BIGINT
);

CREATE TABLE Empleado(
	ID_EMPLEADO BIGINT PRIMARY KEY IDENTITY(1,1),
	NOMBRE VARCHAR(60),
	APELLIDO_PATERNO VARCHAR(60),
	APELLIDO_MATERNO VARCHAR(60),
	NUM_RELOJ BIGINT,
	FOTO VARCHAR(MAX),
	FECHA_INGRESO VARCHAR(60),
	FECHA_EGRESO VARCHAR(60),
	COMPANIA VARCHAR(60),
	PLANTA VARCHAR(60),
	DEPARTAMENTO VARCHAR(60),
	SUPERVISOR VARCHAR(300),
	AREA VARCHAR(60),
	TIPO VARCHAR(60),
	CLASE VARCHAR(60),
	PUESTO VARCHAR(60),
	TURNO VARCHAR(60),
	HORARIO VARCHAR(60),
	IMSS BIGINT,
	RFC VARCHAR(60),
	CURP VARCHAR(60),
	SEXO VARCHAR(60),
	GAFETE VARCHAR(60),
	FORMA_PAGO VARCHAR(60),
	BANCO VARCHAR(60),
	NUMERO_TARJETA BIGINT,
	SALARIO FLOAT,
	DIRECCION VARCHAR(60),
	COLONIA VARCHAR(60),
	NACIONALIDAD VARCHAR(60),
	ESTADO VARCHAR(60),
	MUNICIPIO VARCHAR(60),
	CODIGO_POSTAL BIGINT,
	TELEFONO BIGINT,
	CEL BIGINT,
	FECHA_NACIMIENTO VARCHAR(60),
	ESTADO_CIVIL VARCHAR(60),
	LOCKER VARCHAR(60),
	EMERGENCIA_NOMBRE VARCHAR(60),
	EMERGENCIA_APELLIDO_PATERNO VARCHAR(60),
	EMERGENCIA_APELLIDO_MATERNO VARCHAR(60),
	EMERGENCIA_PARENTEZCO VARCHAR(60),
	EMERGENCIA_TELEFONO BIGINT,
	EMERGENCIA_DIRECCION VARCHAR(60),
	NIVEL_ESCOLAR VARCHAR(60),
	NOMBRE_ESCUELA VARCHAR(60),
	DIRECCION_ESCUELA VARCHAR(60),
	EGRESO_ESCUELA VARCHAR(60),
	ID_CURSO BIGINT
);
CREATE TABLE EmpleadoCurso(
	ID_EMPLEADO_CURSO INT PRIMARY KEY IDENTITY(1,1),
	ID_EMPLEADO BIGINT,
	ID_CURSO BIGINT,
	FOREIGN KEY (ID_EMPLEADO) REFERENCES Empleado(ID_EMPLEADO),
	FOREIGN KEY (ID_CURSO) REFERENCES Curso(ID_CURSO)
)