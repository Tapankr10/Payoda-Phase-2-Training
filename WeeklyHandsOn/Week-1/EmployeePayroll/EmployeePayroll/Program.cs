using EmployeePayroll;

internal class Program
{
    private static void Main(string[] args)
    {

        String choice;
        Console.WriteLine("Enter Details ");
        Console.WriteLine("Enter the type of Employee: ");
        choice = Console.ReadLine();

        switch (choice.ToLower())
        {
            case "permanent":  Console.WriteLine("Employee Id:");
                                int permId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Employee Name:");
                                string permName = Console.ReadLine();
                                Console.WriteLine("Basic Salary:");
                                float permBasicSal = float.Parse(Console.ReadLine());
                                Console.WriteLine("PF:");
                                int permPf = Convert.ToInt32(Console.ReadLine());

                                PermanentEmployee permObj = new PermanentEmployee()
                                {
                                    Id = permId,
                                    Name = permName,
                                    pf = permPf,
                                    BasicSalary = permBasicSal
                                };
                                permObj.NetSalary = permObj.CalculateSalary(permId, permName, permBasicSal);
                                permObj.Bonus = permObj.CalculateBonus(permBasicSal, permPf);

                                Console.WriteLine("The details are:");
                                Console.WriteLine("Employee Id: " + permObj.Id);
                                Console.WriteLine("Employee Name: " + permObj.Name);
                                Console.WriteLine("Basic Salary: " + permObj.BasicSalary);
                                Console.WriteLine("PF: " + permObj.pf);
                                Console.WriteLine("Bonus: " + permObj.Bonus);
                                Console.WriteLine("Net Salary: " + permObj.NetSalary);
                                break;


            case "temporary":
                                Console.WriteLine("Employee Id:");
                                int eid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Employee Name:");
                                string ename = Console.ReadLine();
                                Console.WriteLine("Daily Wages:");
                                int wages = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("No.of days worked:");
                                int day = Convert.ToInt32(Console.ReadLine());
                                TemporaryEmployee tobj = new TemporaryEmployee() { Id = eid, Name = ename, DailyWages = wages, NoOfDays = day };
                                tobj.NetSalary = tobj.CalculateSalary(eid, ename, tobj.BasicSalary);
                                tobj.CalculateBonus(tobj.BasicSalary, wages);
                                Console.WriteLine("The details are:");
                                Console.WriteLine("Employee Id:" + tobj.Id);
                                Console.WriteLine("Employee Name:" + tobj.Name);
                                Console.WriteLine("Daily Wages:" + tobj.DailyWages);
                                Console.WriteLine("No.of days worked:" + tobj.NoOfDays);
                                Console.WriteLine("Bonus:" + tobj.Bonus);
                                Console.WriteLine("Net Salary:" + tobj.NetSalary);
                                break;









        }
    }
}