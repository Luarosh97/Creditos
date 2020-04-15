using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Credito
    {
        public int NumeroCredito{ get; set; }
        public string Identificacion { get; set; }
        

        public string TipoCredito { get; set; }

       public double TasaInteres { get; set; }

        public double Capital { get; set; }

        public double PeriodoTiempo { get; set; }

        public double  CapitalFinal { get; set; }
        public abstract void CalcularCapitalFinal();


        public Credito(int numeroCredito,string identificacion,  string tipoCredito, double tasaInteres, double capital, double periodoTiempo)
        {
            NumeroCredito = numeroCredito;
            Identificacion = identificacion;
            TipoCredito = tipoCredito;
            TasaInteres = tasaInteres;
            Capital = capital;
            PeriodoTiempo = periodoTiempo;
            
        }

        public override string ToString()
        {
            return $"{NumeroCredito};{Identificacion};{TipoCredito};{TasaInteres};{Capital};{PeriodoTiempo};{CapitalFinal}";
        }


    }
}
