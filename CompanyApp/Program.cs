using Business.Services;
using CompanyApp.Controllers;
using Domain.Models;
using System.Net.Mail;
using System.Xml.Linq;
using Utilities.Helpers;



Helper Helper = new();
EmployeeController employeeController = new();
DepartmentController departmentController = new();
Helper.MessageAndItsColor(ConsoleColor.White, MessageConstants.WelcomeMessage);

int number;
while (true)
{
    //Console.WriteLine((MenuEnums[])Enum.GetValues(typeof(MenuEnums)).Length.ToString);
    //foreach (MenuEnums @enum in (MenuEnums[])Enum.GetValues(typeof(MenuEnums)))
    //{
    //    Console.WriteLine((int)@enum);
    //}
    Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.ChooseNumberMessage);
    Helper.MessageAndItsColor(ConsoleColor.Green, MessageConstants.MenuMessage);
    string menuNumber = Console.ReadLine();
    bool result = int.TryParse(menuNumber, out number);
    if (result && number < 17 && number > 0)
    {
        switch (number)
        {
            case (int)MenuEnums.CreateDepartment:
                departmentController.Create();
                break;
            case (int)MenuEnums.UpdateDepartment:
                departmentController.Update();
                break;
            case (int)MenuEnums.DeleteDepartment:
                departmentController.Delete();
                break;
            case (int)MenuEnums.GetDepartmentById:
                departmentController.GetDepartmentById();
                break;
            case (int)MenuEnums.GetAllDepartments: 
                departmentController.GetAllDepartments();
                break;
            case (int)MenuEnums.SearchMethodforDepartments:
                departmentController.SearchMethodforDepartments();
                break;
            case (int)MenuEnums.CreateEmployee:
                employeeController.Create();
                break;
            case (int)MenuEnums.UpdateEmployee:
                employeeController.UpdateEmployee();
                break;
            case (int)MenuEnums.GetEmployeeById:
                employeeController.GetEmployeeById();
                break;
            case (int)MenuEnums.DeleteEmployee:
                employeeController.DeleteEmployee();
                break;
            case (int)MenuEnums.GetEmployeesByAge:
                employeeController.GetEmployeesByAge();
                break;
            case (int)MenuEnums.GetEmployeesByDepartmentId:
                employeeController.GetEmployeesByDepartmentId();
                break;
            case (int)MenuEnums.GetAllEmployeesByDepartmentName:
                employeeController.GetAllEmployeesByDepartmentName();
                break;
            case (int)MenuEnums.SearchMethodforEmployeesByNameOrSurname:
                employeeController.SearchMethodforEmployeesByNameOrSurname();
                break;
            case (int)MenuEnums.GetAllEmployeesCount:
                employeeController.GetAllEmployeesCount();
                break;
            case (int)MenuEnums.GetAllEmployees:
                employeeController.GetAllEmployees();
                break;
            case (int)MenuEnums.ExitProgram:
                return;
            default:
                break;
        }
    }
    else
    {
        Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.SmthngHappenWrong);
    }
}
