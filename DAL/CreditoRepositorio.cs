using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

using System.IO;

namespace DAL
{
    public class CreditoRepositorio
    {
        private string ruta = @"Creditos.txt";
        public List<Credito> creditos;

        public CreditoRepositorio()
        {
            creditos = new List<Credito>();
        }
        public void Guardar(Credito credito)

        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter stream = new StreamWriter(fileStream);
            stream.WriteLine(credito.ToString());
            stream.Close();
            fileStream.Close();

        }




        public List<Credito> Consultar()
        {
            creditos.Clear();
            FileStream filestream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(filestream);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {

                Credito credito = MapearCredito(linea);
                creditos.Add(credito);
            }
            filestream.Close();
            reader.Close();
            return creditos;



        }

        public Credito MapearCredito(string linea)
        {
            string[] datos = linea.Split(';');
            int NumeroCredito= int.Parse(datos[0]);
            string Identificacion = datos[1];
            string TipoCredito = datos[2];
           double TasaInteres =double.Parse(datos[3]);
            double Capital = double.Parse(datos[4]);
            double PeriodoTiempo =double.Parse(datos[5]);
            double CapitalFinal = double.Parse(datos[6]);
           
            if (datos[2] == "Compuesto")
            {
               Credito creditocompuesto = new CreditoCompuesto(NumeroCredito, Identificacion,TasaInteres, Capital,PeriodoTiempo);
               
                creditocompuesto.CapitalFinal= CapitalFinal;

                return creditocompuesto;
            }

            else
            {
                Credito creditosimple = new CreditoSimple(NumeroCredito, Identificacion, TasaInteres, Capital, PeriodoTiempo);
                creditosimple.CapitalFinal = CapitalFinal;
                return creditosimple;

            }

        }
        public void Eliminar(int NumeroCredito)
        {
            creditos.Clear();
            creditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in creditos)
            {
                if (item.NumeroCredito != NumeroCredito)
                {
                    Guardar(item);
                }
            }

        }

        public Credito Buscar(int numerocredito)
        {
            creditos.Clear();
            creditos= Consultar();

            foreach (var item in creditos)
            {
                if (item.NumeroCredito.Equals(numerocredito))
                {
                    return item;
                }
            }
            return null;
        }

        public void Modificar(Credito credito)
        {
            creditos.Clear();
           creditos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in creditos)
            {
                if (item.NumeroCredito != credito.NumeroCredito)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(credito);
                }
            }

        }
    }
}
