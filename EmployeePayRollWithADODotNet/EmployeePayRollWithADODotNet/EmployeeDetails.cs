using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollWithADODotNet
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime Startdate { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Department { get; set; }
        public double Deduction { get; set; }
        public double Taxable_Pay { get; set; }
        public double Net_Pay { get; set; }
    }
}
