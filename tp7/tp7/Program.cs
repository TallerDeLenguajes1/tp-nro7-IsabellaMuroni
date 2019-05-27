using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp7
{
    class Program
    {
        public struct Empleado
        {
            public string Nombre;
            public string Apellido;
            public DateTime FNac;
            public int Edad;
            public EstadoCivil EstadoCivil;
            public Genero Genero;
            public DateTime FechaIng;
            public int Antiguedad;
            public int sueldoBasico;
            public Cargo Cargo;

            public void MostrarEmpleados()
            {
                Console.WriteLine("Nombre: {0}", Nombre);
                Console.WriteLine("Apellido: {0}", Apellido);
                Console.WriteLine("Fecha de nacimiento: {0}", FNac);
                Console.WriteLine("Edad: {0}", Edad);
                Console.WriteLine("Estado civil: {0}", EstadoCivil);
                Console.WriteLine("Género: {0}", Genero);
                Console.WriteLine("Fecha de ingreso: {0}", FechaIng);
                Console.WriteLine("Antigüedad: {0}", Antiguedad);
                Console.WriteLine("Sueldo Básico: $ {0}", sueldoBasico);
                Console.WriteLine("Cargo: {0}", Cargo);
            }

            
        } 

        public enum Genero { masculino, femenino };
        public enum EstadoCivil { casado, soltero };
        public enum Cargo { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador };

        //Para cargar nombres y apellidos
        static string[] nombreEmpleados = { "Ignacio", "Marcos", "Nicolas", "Felipe", "María", "Lucia", "Patricia", "Macarena" };
        static string[] apellidoEmpleados = { "Guerrero", "Ruiz", "Perez", "Torres", "Moreno","Menendez", "Cisneros", "Lopez" };

        static void Main(string[] args)
        {
            Empleado empleado;
            //for (int i = 0; i < 20; i++)
            //{

            //    Console.WriteLine("* * * Empleado * * *");
            //    empleado = CrearEmpleadoNuevo();
            //    empleado.MostrarEmpleados();
            //    Console.WriteLine("------");
            //}
            empleado = CrearEmpleadoNuevo();
            empleado.MostrarEmpleados();

            Console.ReadKey();
        }

        public static DateTime FechaNac()
        {
            DateTime fechaInicio = new DateTime(1960, 1, 1);
            DateTime fechaTope = new DateTime(2000, 1, 1);
            TimeSpan days = (fechaTope - fechaInicio);
            int Dias = days.Days;
            Random rand = new Random();
            int diasAleatorios = rand.Next(Dias);
            DateTime fechaNac = fechaInicio.AddDays(diasAleatorios);
            //Console.Write("{0}", fechaNac);

            return fechaNac;
        }

        public static DateTime FechaIngreso()
        {
            DateTime fechaInicio = new DateTime(1940, 1, 1);
            DateTime fechaActual = DateTime.Today;
            TimeSpan days = (fechaActual - fechaInicio);
            int Dias = days.Days;
            Random rand = new Random();
            int diasAleatorios = rand.Next(Dias);
            DateTime fechaIngreso = fechaInicio.AddDays(diasAleatorios);
            
            return fechaIngreso;
        }

        public static int CalcularEdad( DateTime fechaNacimiento )
        {
            DateTime fechaActual = DateTime.Today;
            //TimeSpan anios = (fechaActual - fechaNacimiento);
            //int Edad = new DateTime((fechaActual - fechaNacimiento).Ticks).Year;
            int Edad = (fechaActual.Year - fechaNacimiento.Year);

            return Edad;
        }

        public static int CalcularAntiguedad(DateTime fechaIngreso)
        {
            DateTime _fechaActual = DateTime.Today;
            int antiguedad = (_fechaActual.Year - fechaIngreso.Year);

            return antiguedad;
        }

        //public static int calcularJubilacion(int Edad, Genero genero)
        //{
        //    if (genero == Genero.femenino)
        //    {
        //        int Jubilacion = 60 - Edad;
        //    }
        //    else
        //    {
        //        int Jubilacion = 65 - Edad;
        //    }

        //    return Jubilacion;
        //}

        //public static int CalcularSalario(int Sueldo, int Antiguedad, Cargo cargo)
        //{
        //    if(Antiguedad < 20)
        //    {
        //        if(Cargo == Cargo.Ingeniero || Cargo == Cargo.Especialista)
        //        {
        //            int Adicional = (Sueldo * 1.50);
        //        }
        //        else
        //        {
        //            int Adicional = (Sueldo * 0.20);
        //        }
        //    }
        //    else
        //    {
        //        if (Cargo == Cargo.Ingeniero || Cargo == Cargo.Especialista)
        //        {
        //            int Adicional = (Sueldo * 1.50);
        //        }
        //        else
        //        {
        //            int Adicional = (Sueldo * 0.25);
        //        }
        //    }
        //    int Salario = Sueldo + Adicional;

        //    return Salario;
        //}
        public static Empleado CrearEmpleadoNuevo()
        {
            Empleado MiEmpleado = new Empleado();

            Random rn = new Random();
            int aleatorio = rn.Next(8);

            string _Nombre = nombreEmpleados[aleatorio];
            MiEmpleado.Nombre = _Nombre;

            string _Apellido = apellidoEmpleados[aleatorio];
            MiEmpleado.Apellido = _Apellido;

            DateTime FechaNacimiento = FechaNac();
            MiEmpleado.FNac = FechaNacimiento;

            int EDAD = CalcularEdad(FechaNacimiento);
            MiEmpleado.Edad = EDAD;

            Random rand = new Random();
            int aleatorio2 = rand.Next(2);

            MiEmpleado.Genero = (Genero)aleatorio2;

            DateTime _FechaIngreso = FechaIngreso();
            MiEmpleado.FechaIng = _FechaIngreso;

            int antig = CalcularAntiguedad(_FechaIngreso);
            MiEmpleado.Antiguedad = antig;

            MiEmpleado.EstadoCivil = (EstadoCivil)aleatorio2;

            Random ramd = new Random();
            int sueldoale = ramd.Next(10000, 30000);
            MiEmpleado.sueldoBasico = sueldoale;

            Random rd = new Random();
            int aleatorio3 = rd.Next(5);
            MiEmpleado.Cargo = (Cargo)aleatorio3;

            return MiEmpleado;
        }
    }
}
