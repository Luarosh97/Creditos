using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CreditoSimple : Credito
    {
       

          public CreditoSimple(int numeroCredito, string identificacion,  double tasaInteres, double capital, double periodoTiempo) : base(numeroCredito, identificacion, "Simple", tasaInteres, capital, periodoTiempo)
        {
        }

        public override void CalcularCapitalFinal()
        {
            CapitalFinal = Capital * (1 + TasaInteres*PeriodoTiempo);
        }
    }
}
