using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    internal class PermanentEmployee : Employee
    {
       public  int pf { get; set; }
        public override float CalculateSalary(int id, string name, float basicSalary)
        {

            return basicSalary - pf;
        }
        public  override float CalculateBonus(float salary, int pf)
        {
            if (pf < 1000)
            {
                Bonus = 0.10f * salary;
            }
            else if (pf >= 1000 && pf < 1500)
            {
                Bonus = 0.115f * salary;
            }
            else if (pf >= 1500 && pf < 1800)
            {
                Bonus = 0.12f * salary;
            }
            else
            {
                Bonus = 0.15f * salary;
            }
            return Bonus;
        }

    }
}
