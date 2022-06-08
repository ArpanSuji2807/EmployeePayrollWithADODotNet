using System;
using EmployeePayRollWithADODotNet;
class program
{
    public static void Main(string[] args)
    {
        EmpRepository repository = new EmpRepository();
        bool check = true;
        Console.WriteLine("1.Add Employee data\n2.Retrive Employee data\n3.Update salary\n4.Delete employee details\n5.Retrive employee details by data range");
        while(check)
        {
            Console.WriteLine("Choose an option");
            int option = Convert.ToInt32(Console.ReadLine());
            switch(option)
            {
                case 1:
                    EmployeeDetails details = new EmployeeDetails();
                    details.Id = 5;
                    details.Name = "";
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
                    List<EmployeeDetails> empList = repository.RetrieveEmployeeData();
                    foreach (EmployeeDetails data in empList)
                    {
                        Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + " " + data.Gender + " " + data.Startdate  + " " + data.PhoneNumber + " " + data.Department + " " + data.Deduction + " " + data.Taxable_Pay + " " + data.Net_Pay );
                    }
                    break;
                case 3:
                    EmployeeDetails detail = new EmployeeDetails();
                    detail.Id = 1;
                    detail.Salary = 30000;
                    repository.UpdateEmployeeSalary(detail);
                    break;
                case 4:
                    EmployeeDetails employee = new EmployeeDetails();
                    employee.Id = 5;
                    employee.Name = "Arpan";
                    repository.DeleteEmployeeDetails(employee);
                    break;
                case 5:
                    List<EmployeeDetails> employees = repository.RetrieveEmployeeData();
                    Console.WriteLine("Enter date: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    repository.RetrieveEmployeesVByDataRange(date);
                    foreach(EmployeeDetails data in employees)
                    {
                        if(data.Startdate.Equals(date))
                        {
                            Console.WriteLine(data.Id + " " + data.Name + " " + data.Salary + data.Startdate + " " + data.Gender + " " + data.PhoneNumber + " " + data.Department + " " + data.Deduction + " " + data.Taxable_Pay + " " + data.Net_Pay);
                        }
                    }
                    break;
                case 6:
                    EmployeeDetails emp = new EmployeeDetails();
                    Console.WriteLine("Enter the gender");
                    emp.Gender = Console.ReadLine();
                    repository.FindSumAvgMaxMin(emp);
                    if(emp.Gender == "M")
                    {
                        Console.WriteLine(emp.Salary);
                    }
                    break;
            }
        }
    }
}