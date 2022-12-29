using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Controllers.Enums
{
    public enum MenuController
    {
            CreateDepartment = 1,
            UpdateDepartment,
            DeleteDepartment,
            GetDepartmentById,
            GetAllDepartments,
            SearchMethodforDepartments,
            CreateEmployee,
            UpdateEmployee,
            GetEmployeeById,
            DeleteEmployee,
            GetEmployeesByAge,
            GetEmployeesByDepartmentId,
            GetAllEmployeesByDepartmentName,
            SearchMethodforEmployeesByNameOrSurname,
            GetAllEmployeesCount,
    }
    
}
