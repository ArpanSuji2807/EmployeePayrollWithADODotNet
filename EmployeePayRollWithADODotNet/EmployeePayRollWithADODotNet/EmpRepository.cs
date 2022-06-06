using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollWithADODotNet
{
    public class EmpRepository
    {
        private SqlConnection con;    
        private void connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=Payroll_Service";
            con = new SqlConnection(connectingString);
        }
    }
}
