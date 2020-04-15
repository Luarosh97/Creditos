using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;


namespace CreditoFinanciero
{
    public class Program
    {

        public static CreditoService creditoService = new CreditoService();

        public Program()
        {
            creditoService = new CreditoService();


        }

        static string mensaje;


        static void Main(string[] args)
        {

            int opcion = -1;
            do
            {
                Console.Clear();
                Console.WriteLine("                  Menu De Creditos               ");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("1. Registrar Credito");
                Console.WriteLine("2. Eliminar Credito");
                Console.WriteLine("3. Buscar Credito ");
                Console.WriteLine("4. Modificar el Credito");
                Console.WriteLine("5. Ver listado de creditos");
                Console.WriteLine("0. Salir de la aplicacion\n");
                Console.WriteLine("Digite su opcion: ");
                opcion = ValidarNumeros("Error, debe ingresar una opcion valida ", 0, 5);
                EjecutarOpcion(opcion);
            } while (opcion != 0);
        }
        public static void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Registrar();
                    break;
                case 2:
                    Eliminar();
                    break;
                case 3:
                    Buscar();
                    break;
                case 4:
                    Modificar();
                    break;
                case 5:
                    ConsultarListado();
                    break;
                case 0:
                    break;
            }
        }

        public static void Registrar()
        {
            string cadena;
            do
            {
                Console.Clear();
                Credito credito= RecolectarDatos();
                credito.CalcularCapitalFinal();
                mensaje = creditoService.Guardar(credito);
                Console.WriteLine($"{mensaje}");
                Console.WriteLine("El valor del capital final es: {0}", credito.CapitalFinal);
                Console.WriteLine("¿Desea registrar otro Credito ? S/N");
                cadena = ValidarLetras("Error, tiene que ingresar S o N", "S", "N");
            } while (cadena == "S");
        }
        public static Credito RecolectarDatos()
        {
            Credito credito;
            Console.WriteLine("¿Que tipo de credito desea ingresar? CreditoCompuesto ->(C)  CreditoSimple->(S)");
            string TipoCredito = ValidarLetras("Error, debe ingresar C o S", "C", "S");
            Console.WriteLine("Ingrese numero de credito  :");
            int NumeroCredito = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de identificacion del cliente:");
            string Identificacion = Console.ReadLine();
            Console.WriteLine("Ingrese la tasa de interes :");
            double TasaInteres = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor inicial del capital :");
            double Capital = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el periodo de tiempo  :");
            double PeriodoTiempo = double.Parse(Console.ReadLine());

            
            if (TipoCredito== "C")
            {
                
                credito = new CreditoCompuesto(NumeroCredito, Identificacion, TasaInteres,PeriodoTiempo,Capital);

            }
            else
            {
               
                credito = new CreditoSimple(NumeroCredito, Identificacion, TasaInteres,PeriodoTiempo,Capital);
            }
            return credito;
        }
        public static void Eliminar()
        {
            string cadena;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese el numero del credito a borrar :");
                int NumeroCredito = int.Parse(Console.ReadLine());
                mensaje = creditoService.Eliminar(NumeroCredito);
                Console.WriteLine($"{mensaje}");
                Console.WriteLine("¿Desea borrar algun otro credito ? S/N");
                cadena = ValidarLetras("Error, debe ingresar S o N", "S", "N");
            } while (cadena == "S");
        }
        public static void Buscar()
        {
            string cadena;
            do
            {
                Console.Clear();
                List<Credito> creditos= new List<Credito>();
                Console.WriteLine("Ingrese el numero del credito a buscar:");
                int NumeroCredito = int.Parse(Console.ReadLine());
                Credito credito= creditoService.Buscar(NumeroCredito);
                if (credito != null)
                {
                    Console.WriteLine("Credito Encontrado\n\n");
                    creditos.Add(credito);
                    creditoService.ImprimirCreditosFinancieros(creditos);
                }

                Console.WriteLine("¿Desea buscar otro credito ? S/N");

                cadena = ValidarLetras("Error,  ingrese S o N", "S", "N");

            } while (cadena == "S");
        }
        public static void Modificar()
        {
            string respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese el numero del credito a modificar:");
                int NumeroCredito= int.Parse(Console.ReadLine());
                Credito credito = creditoService.Buscar(NumeroCredito);
                if (credito!= null)
                {
                    Console.WriteLine("Ingrese el nuevo valor del capital inicial:");
                    credito.Capital = double.Parse(Console.ReadLine());
                    credito.CalcularCapitalFinal();
                    creditoService.Modificar(credito);
                    Console.WriteLine($"{mensaje}");
                    Console.WriteLine("El nuevo valor del capital final  es: {0}", credito.CapitalFinal);
                }
                Console.WriteLine("¿Desea editar otro credito ? S/N");
                respuesta = ValidarLetras("Error, debe ingresar S o N", "S", "N");
            } while (respuesta == "S");
        }
        public static void ConsultarListado()
        {
            Console.Clear();
            creditoService.Consultar();
            Console.ReadKey();
        }
        public static int ValidarNumeros(string cadena, int Variable1, int Variable2)
        {
            int opcion;
            do
            {
                opcion = int.Parse(Console.ReadLine());
                if (opcion < Variable1 || opcion > Variable2)
                {
                    Console.WriteLine(cadena);
                    Console.ReadKey();
                }
            } while (opcion < Variable1 && opcion > Variable2);
            return opcion;
        }
        public static string ValidarLetras(string cadena, string Variable1, string Variable2)
        {
            string opcion;
            do
            {
                opcion = Console.ReadLine().ToUpper();
                if (opcion != Variable1 && opcion != Variable2)
                {
                    Console.WriteLine(mensaje + "\n");
                    Console.ReadKey();
                }
            } while (opcion != Variable1 && opcion != Variable2);
            return opcion;
        }


    }
}
