using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DBContext
    {
        public static List<Employee> Employees { get; set; }
        public static List<Department> Departments { get; set; }

        static DBContext()
        {
            Employees = new List<Employee>();
            Departments = new List<Department>();
        }
    }
}
