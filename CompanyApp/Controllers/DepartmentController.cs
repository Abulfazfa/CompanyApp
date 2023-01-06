using Business.Interfaces;
using Business.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utilities.Helpers;

namespace CompanyApp.Controllers
{

    public class DepartmentController
    {
        Helper Helper = new();
        private readonly DepartmentService departmentService;
        private readonly EmployeeService employeeService;
        public DepartmentController()
        {
            departmentService = new DepartmentService();
            employeeService = new EmployeeService();
        }

        public void Create()
        {
            DepartmentName: Helper.MessageAndItsColor(ConsoleColor.Magenta, MessageConstants.DepartmentName);

            string name = Console.ReadLine();
            if (name == "")
            {
                goto DepartmentName;
            }
            EnterDepartmantCapacity: Helper.MessageAndItsColor(ConsoleColor.Magenta, MessageConstants.DepartmentCapasity);
            int capasity;
            string capasityAcceptor = Console.ReadLine();
            if (int.TryParse(capasityAcceptor, out capasity))
            {
                Department department = new();
                department.Name = name;
                department.Capasity = capasity;

                if (departmentService.Create(department))
                {
                    Console.WriteLine($"---{name} {MessageConstants.DepartmentCreated}---");
                    return;
                }
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.DepartmentNotCreated);
            }
            else
            {
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.WrongNumber);
                goto EnterDepartmantCapacity;
            }
        }

        public void Update()
        {
            Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.DepartmentName);
            string? name = Console.ReadLine();
            Department findDepartment = departmentService.Get(dep => dep.Name.ToLower() == name.ToLower());
            if (findDepartment != null)
            {
                Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.SureMessage);
                if (SureMessage())
                {
                    Department department = new();
                    Console.WriteLine("New name");
                    string? newname = Console.ReadLine();
                    if (newname != "")
                    {
                        department.Name = newname;
                    }
                    Capacity: Console.WriteLine("New capasity");                                      
                    string capasityAcceptor = Console.ReadLine();
                    int capacity;
                    if (int.TryParse(capasityAcceptor, out capacity))
                    {
                        department.Capasity = capacity;
                    }
                    else
                    {
                        if (capasityAcceptor != "")
                        {
                            Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.SmthngHappenWrong);                      
                            goto Capacity;
                        }
                    }

                    if (departmentService.Update(name, department))
                    {
                        Helper.MessageAndItsColor(ConsoleColor.Green, MessageConstants.EmployeeUpdated);
                    }
                    else
                    {
                        Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.EmployeeNotUpdated);
                    }
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.ProccessRejected);
                }
            }
            else
            {
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.DepartmentNotFind);
            }
            
        }

        public void Delete()
        {
            Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.DepartmentName);
            string? name = Console.ReadLine();
            Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.SureMessageDelete);
            if (SureMessage())
            {
                Department filtered = departmentService.Get(dep => dep.Name == name);
                foreach (var item in employeeService.GetAllByDepartmentId(filtered.Id))
                {
                    employeeService.Delete(item.Name);
                }

                if (departmentService.Delete(name))
                {
 
                    Helper.MessageAndItsColor(ConsoleColor.Green, MessageConstants.DepartmentDelete);
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.DepartmentNotFind);
                }
            }
            else
            {
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.ProccessRejected);
            }


        }

        public void GetDepartmentById()
        {
            EnterDepartmantId: Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.DepartmentId);
            int Id;
            string IdAcceptor = Console.ReadLine();
            if (int.TryParse(IdAcceptor, out Id))
            {
                Department filteredDepartment = departmentService.GetById(Id);

                if (filteredDepartment != null)
                {
                    FullInfo(filteredDepartment);  
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.DepartmentNotFind);
                }
                
            }
            else
            {
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.WrongNumber);
                goto EnterDepartmantId;
            }           
        }

        public void GetAllDepartments()
        {
            foreach (var item in departmentService.GetAll())
            {
                FullInfo(item);
            }

        }

        public void SearchMethodforDepartments()
        {
            Console.WriteLine("Enter name or capacity");
            int intData;
            string data = Console.ReadLine();
            if (int.TryParse(data, out intData))
            {
                List<Department> capasityList = departmentService.SearchMethodforDepartments(e => e.Capasity == intData);
                if (capasityList.Count != 0)
                {
                    foreach (var item in capasityList)
                    {
                        FullInfo(item);
                    }
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.NotFind);
                }
            }
            else
            {
                List<Department> nameList = departmentService.SearchMethodforDepartments(e => e.Name == data);
                if (nameList.Count != 0)
                {
                    foreach (var item in nameList)
                    {
                        FullInfo(item);
                    }
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.NotFind);
                }
            }

            
          
        }

        private bool SureMessage()
        {
            string? name = Console.ReadLine();
            return name == "Y";
        }
        private void FullInfo(Department department)
        {
            Console.WriteLine($" Id - {department.Id} | name - {department.Name} | capasity - {department.Capasity}");
        }
    }
}
