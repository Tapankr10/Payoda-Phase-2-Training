using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    internal class TemporaryEmployee: Employee
    {
        public int DailyWages;
        public int NoOfDays;

        public override float CalculateSalary(int ID, string Name, float BasicSalary)
        {
            NetSalary = DailyWages * NoOfDays;
            return NetSalary;
        }
        public override float CalculateBonus(float salary, int criteria)
        {
            if (DailyWages < 1000)
            {
                Bonus = 0.15f * NetSalary;
            }
            else if (DailyWages >= 1000 && DailyWages < 1500)
            {
                Bonus = 0.12f * NetSalary;
            }
            else if (DailyWages >= 1500 && DailyWages < 1750)
            {
                Bonus = 0.11f * NetSalary;
            }
            else
            {
                Bonus = 0.08f * NetSalary;
            }
            return Bonus;
        }


    }
}
