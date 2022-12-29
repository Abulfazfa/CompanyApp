using Business.Services;
using CompanyApp.Controllers.Enums;
using Domain.Models;
using System.Net.Mail;
using System.Xml.Linq;
using Utilities.Helpers;

DepartmentService departmentService = new();
Helper Helper = new();
Helper.MessageAndItsColor(ConsoleColor.White, MessageConstants.WelcomeMessage);



int number;
while (true)
{
    Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.ChooseNumberMessage);
    Helper.MessageAndItsColor(ConsoleColor.Green, MessageConstants.MenuMessage);
    string menuNumber = Console.ReadLine();
    bool result = int.TryParse(menuNumber, out number);
    if (result && number < 16 && number > 0)
    {
        switch (number)
        {          
            case(int)MenuController.CreateDepartment:
                Helper.MessageAndItsColor(ConsoleColor.Magenta,MessageConstants.DepartmentName);
                string name = Console.ReadLine();
                EnterDepartmantCapacity: Helper.MessageAndItsColor(ConsoleColor.Magenta,MessageConstants.DepartmentCapasity);
                int capasity;
                string capasityAcceptor = Console.ReadLine();
                bool check_capacity = int.TryParse(capasityAcceptor, out capasity);
                if (check_capacity)
                {
                    Department department = new();
                    department.Name = name;
                    department.Capasity = capasity;
                    departmentService.Create(department);
                    Console.WriteLine($"{name} {MessageConstants.DepartmentCreate}");
                }
                else
                {
                    Console.WriteLine(MessageConstants.WrongNumber);
                    goto EnterDepartmantCapacity; 
                }
                break;
            case (int)MenuController.UpdateDepartment:
                UpdateDepartmant: Console.WriteLine(MessageConstants.DepartmentId);
                int id;
                string IdAcceptor = Console.ReadLine();
                if (int.TryParse(IdAcceptor, out id))
                {
                    departmentService.Update(id);
                    Console.WriteLine(MessageConstants.DepartmentUpdate);
                }
                else
                {
                    Console.WriteLine(MessageConstants.WrongNumber);
                    goto UpdateDepartmant;
                }
                break;
            case (int)MenuController.DeleteDepartment:
                string department_name = Console.ReadLine();
                
                    //varmi yoxla

                break;
            case (int)MenuController.GetDepartmentById:
                
                break;
            case (int)MenuController.GetAllDepartments:
                departmentService.GetAll();
                break;
            case (int)MenuController.SearchMethodforDepartments:
                break;
            case (int)MenuController.CreateEmployee:
                break;
            case (int)MenuController.UpdateEmployee:
                break;
            case (int)MenuController.GetEmployeeById:
                break;
            case (int)MenuController.DeleteEmployee:
                break;
            case (int)MenuController.GetEmployeesByAge:
                break;
            case (int)MenuController.GetEmployeesByDepartmentId:
                break;
            case (int)MenuController.GetAllEmployeesByDepartmentName:
                break;
            case (int)MenuController.SearchMethodforEmployeesByNameOrSurname:
                break;
            case (int)MenuController.GetAllEmployeesCount:
                break;
      
            default:
                break;
        }
    }
}


