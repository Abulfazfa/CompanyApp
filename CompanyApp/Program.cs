using Business.Services;
using Domain.Models;
using System.Net.Mail;
using System.Xml.Linq;
using Utilities.Helpers;

DepartmentService departmentService = new();
Helper Helper = new();
Helper.MessageAndItsColor(ConsoleColor.White,MessageConstants.WelcomeMessage);
Helper.MessageAndItsColor(ConsoleColor.Green,MessageConstants.MenuMessage);

int number;
while (true)
{
    string menuNumber = Console.ReadLine();
    bool result = int.TryParse(menuNumber, out number);
    if (result && number < 16 && number > 0)
    {
        switch (number)
        {          
            case 1:
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
            case 2:
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
            case 3:
                string department_name = Console.ReadLine();
                if ()
                {
                    //varmi yoxla
                }
                departmentService.Delete();
                break;
            case 4:
                departmentService.GetById();
                break;
            case 5:
                departmentService.GetAll();
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            default:
                break;
        }
    }
}


