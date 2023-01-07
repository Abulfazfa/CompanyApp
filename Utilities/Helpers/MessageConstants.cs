using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helpers
{
    public static class MessageConstants
    {
        public const string WelcomeMessage = "Welcome!!!";
        public const string ChooseNumberMessage = "Please sellect one number";
        public const string MenuMessage = "1 - Create Department\n" +
    "2 - Update Department\n" +
    "3 - Delete Department\n" +
    "4 - Get department  by id\n" +
    "5 - Get all departments\n" +
    "6 - Search method for departments\n" +
    "7 - Create employee\n" +
    "8 - Update employee\n" +
    "9 - Get employee by id\n" +
    "10 - Delete employee\n" +
    "11 - Get employees by age\n" +
    "12 - Get employees by departmentId\n" +
    "13 - Get all employees  by departmentName\n" +
    "14 - Search method for employees by name or surname\n" +
    "15 - Get all employees count\n" +
    "16 - Get all employees \n" +
    "17 - Exit Program";
        public const string DepartmentName = "Please enter the department's name";
        public const string DepartmentCapasity = "Please enter the department's capasity";
        public const string DepartmentCreated = "department is created successfully";
        public const string DepartmentNotCreated = "There is already a department with that name";
        public const string DepartmentNotFind = "There is no a department with that name";
        public const string SmthngHappenWrong = "Something went wrong";
        public const string WrongNumber = "You enter a wrong number";
        public const string DepartmentId = "Please enter the department's Id";
        public const string DepartmentUpdate = " The department is updated successfully";
        public const string ProccessRejected = "Proccess is rejected";
        public const string DepartmentDelete = " The department is deleted successfully";
        public const string SureMessage = " Are you sure?\n If yes press 'Y' or press any buttom";
        public const string SureMessageDelete = " Are you sure? Employees of this department will delete.\n If yes press 'Y' or press any buttom";

        public const string EmployeeName = "Please enter the employee's name";
        public const string EmployeeId = "Please enter the employee's Id";
        public const string EmployeeSurname = "Please enter the employee's surname";
        public const string EmployeeAge = "Please enter the employee's age";
        public const string EmployeeDepartmentId = "Please enter the employee's department Id";  
        public const string EmployeeDepartmentName = "Please enter the employee's department name";  
        public const string EmployeeAddress = "Please enter employee's address";
        public const string EmployeeCreated = "is created successfully";
        public const string EmployeeUpdated = "The employee was updated successfully";
        public const string EmployeeNotUpdated = "The employee wasn't updated";
        public const string EmployeeNotCreated = "Employee wasn't created";
        public const string EmployeeDeleted = "The employee was deleted";
        public const string EmployeeNotFind = "There is no a employee with that name";
        public const string NotFind = "Nothing finded";
        public const string EmployeeCount = "Employees' count is ";


    }
}
