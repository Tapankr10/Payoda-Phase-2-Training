using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances
{
    class LifeInsurance :Insurance
    {
        int policyTerm;
        float benefitPercent;

        public int PolicyTerm { get { return policyTerm; } set { policyTerm = value; } }
        public float BenefitPercent { get { return benefitPercent; } set { benefitPercent = value; } }
        public  double calculatePremium()
        {
           return (AmountCovered -((AmountCovered* BenefitPercent)/100)) / PolicyTerm;
          
        }
    }
}
