using System;
using EmployeePayRollWithADODotNet;
class program
{
    public static void Main(string[] args)
    {
        EmpRepository repository = new EmpRepository();
        bool check = true;
        Console.WriteLine("1.Add Employee data\n2.Retrive Employee data\n3.Update salary");
        while(check)
        {
            Console.WriteLine("Choose an option");
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    EmployeeDetails details = new EmployeeDetails();
                    details.EmpId = 1;
                    details.Name = "Arpan";
                    details.Salary = 40000;
                    details.Startdate = DateTime.Now;
                    details.Gender = "M";
                    details.PhoneNumber = 235555;
                    details.Department = "Marketing";
                    details.Deduction = 500;
                    details.Taxable_Pay = 300;
                    details.Net_Pay = 20000;
                    repository.AddEmployee(details);
                    break;
                case 2:
                    repository.RetrieveEmployeeData();
                    break;
                case 3:
                    EmployeeDetails detail = new EmployeeDetails();
                    detail.EmpId = 1;
                    detail.Salary = 30000;
                    repository.UpdateEmployeeSalary(detail);
                    break;
            }
        }
    }
}