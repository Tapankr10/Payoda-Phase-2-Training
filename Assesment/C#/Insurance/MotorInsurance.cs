using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances
{
    class MotorInsurance:Insurance
    {


        double idv;
        double depPercent;

        public double Idv { get { return idv; } set { idv = value; } }
       public double DepPercent { get { return depPercent; } set { depPercent = value; } }
        public  double calculatePremium()
        {
          Idv = AmountCovered -((AmountCovered * depPercent) / 100);

            return 0.03 * Idv;
        }
    }
}
