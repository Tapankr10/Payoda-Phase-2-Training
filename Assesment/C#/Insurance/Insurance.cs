using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances
{
    class Insurance
    {

        string insuranceNo;
        string insuranceName;
      public   double amountCovered;
    public   string InsuranceNo { get {return insuranceNo;}  set { insuranceNo = value; } }
     public    string InsuranceName{get {return insuranceName;} set { insuranceName = value; }}
     public double AmountCovered { get { return amountCovered; } set { amountCovered = value; } }

     /*   public Insurance( String InsuranceNo,String InsuranceName, double AmountCovered )
        {
            this.insuranceNo = InsuranceNo;
            this.insuranceName = InsuranceName;
            this.AmountCovered = AmountCovered;

        }*/

    // public virtual  double calculatePremium();
    }
}
