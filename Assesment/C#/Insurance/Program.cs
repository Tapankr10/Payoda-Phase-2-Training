using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insurance Number :");

            String  no = Console.ReadLine();

            Console.WriteLine("Insurance Name :");
            String name = Console.ReadLine();
            Console.WriteLine("Amount Covered :");

            double amount= Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select");
            Console.WriteLine("1.Life Insurancet");

            Console.WriteLine("2.Motor Insurance");

            int  op = Convert.ToInt32(Console.ReadLine());

            if(op ==1)
            {
               // Insurance ins = new Insurance() { };//String InsuranceNo,String InsuranceName, double AmountCovered
                Console.WriteLine("Policy Term :");

                int pt = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Benefit Percent :");

                float bt =float.Parse(Console.ReadLine());

                LifeInsurance lt = new LifeInsurance() {InsuranceNo = no, InsuranceName = name, AmountCovered = amount , PolicyTerm = pt, BenefitPercent = bt };

                Console.WriteLine("Calculated Premium:" + lt.calculatePremium());

                Console.ReadKey();
                
            }
            else if (op == 2)
            {
               
                Console.WriteLine("Depreciation Percent :");

                Double dp = float.Parse(Console.ReadLine());
                MotorInsurance mt = new MotorInsurance() { InsuranceNo = no, InsuranceName = name, AmountCovered = amount, DepPercent = dp };
                Console.WriteLine("Calculated Premium:"+   mt.calculatePremium());
                //Calculated Premium


                Console.ReadKey();
               
            }
            else
            {
                Console.WriteLine("Enter Valid Input");
            }





        }
    }
}
