using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;


namespace BLL
{
    public class CreditoService
    {
        private CreditoRepositorio creditoRepositorio;

        public CreditoService()
        {
            creditoRepositorio = new CreditoRepositorio();
        }
        public string Guardar(Credito credito)
        {
            try
            {
                if (creditoRepositorio.Buscar(credito.NumeroCredito) == null)
                {
                    creditoRepositorio.Guardar(credito);
                    return $"Los datos del credito numero {credito.NumeroCredito} han sido guardados correctamente";
                }
                return $"No es posible registrar el credito con numero {credito.NumeroCredito}, porque ya se encuentra registrada";
            }
            catch (Exception E)
            {
                return "Error de lectura " + E.Message;
            }
        }
        public string Eliminar(int numerocredito)
        {
            try
            {
                Credito credito = creditoRepositorio.Buscar(numerocredito);
                if (credito != null)
                {
                    creditoRepositorio.Eliminar(numerocredito);
                    Console.WriteLine($"Los datos del credito  {numerocredito} han sido eliminados correctamente");
                    return null;
                }
                Console.WriteLine($"No es posible eliminar el credito{numerocredito}, porque no se encuentra registrado");
                return null;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura " + E.Message);
                return null;
            }
        }
        public void Modificar(Credito credito)
        {
            try
            {
                creditoRepositorio.Modificar(credito);
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura" + E.Message);
            }

        }
        public void Consultar()
        {
            try
            {
                List<Credito> creditos = creditoRepositorio.Consultar();
                if (creditos!= null)
                {
                    ImprimirCreditosFinancieros(creditos);
                }
                else
                {
                    Console.WriteLine("No existen creditos registrados  en la lista");
                }
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura " + E.Message);
            }
        }
        public void ImprimirCreditosFinancieros(List<Credito> credito)
        {
            Console.WriteLine("{0,15}{1,17}{2,16}{3,12}{4,16}{5,17}", "Nro. Credito", "Identificacion", "Tipo_Credito", "Tasa_interes", "Capital", "Periodo_Tiempo","Capital_Final");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (var item in credito)
            {
                Console.WriteLine("{0,15}{1,17}{2,16}{3,12}{4,16}{5,17}", item.NumeroCredito, item.Identificacion,  item.TipoCredito, item.TasaInteres, item.Capital,item.PeriodoTiempo,item.CapitalFinal);
            }


        }
        public Credito Buscar(int numerocredito)
        {
            try
            {
                Credito credito = creditoRepositorio.Buscar(numerocredito);
                if (credito == null)
                {
                    Console.WriteLine($"El credito {numerocredito} no se encuentra registrada");
                }
                return credito;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura " + E.Message);
                return null;
            }





        }
    }
}
