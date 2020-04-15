using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class CreditoCompuesto : Credito
    {
        public CreditoCompuesto(int numeroCredito, string identificacion,  double tasaInteres,double capital, double periodoTiempo) : base(numeroCredito, identificacion, "compuesto", tasaInteres, capital, periodoTiempo)
        {
        }

        public override void CalcularCapitalFinal()
        {
            CapitalFinal = (Capital * Math.Pow((1 + TasaInteres), (PeriodoTiempo)));
        }
    }
}
