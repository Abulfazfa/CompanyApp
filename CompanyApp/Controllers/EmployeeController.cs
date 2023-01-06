using Business.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace CompanyApp.Controllers
{
    public class EmployeeController
    {
        Helper Helper = new();
        private readonly EmployeeService employeeService;
        private readonly DepartmentService departmentService;
        public EmployeeController()
        {
            employeeService = new EmployeeService();             
            departmentService = new DepartmentService();             
        }
        public void Create()
        {
            try
            {
                EnterName: Helper.MessageAndItsColor(ConsoleColor.Magenta, MessageConstants.EmployeeName);
                string name = Console.ReadLine();
                if (name == "")
                {
                    goto EnterName;
                }
                EnterSurname: Helper.MessageAndItsColor(ConsoleColor.Magenta, MessageConstants.EmployeeSurname);
                string surname = Console.ReadLine();
                if (surname == "")
                {
                    goto EnterSurname;
                }
                Helper.MessageAndItsColor(ConsoleColor.Magenta, MessageConstants.EmployeeAddress);
                string address = Console.ReadLine();

                EnterEmployeeAge: Helper.MessageAndItsColor(ConsoleColor.Magenta, MessageConstants.EmployeeAge);
                int age;
                string ageAcceptor = Console.ReadLine();
                if (!int.TryParse(ageAcceptor, out age))
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.WrongNumber);
                    goto EnterEmployeeAge;
                }

                EnterDepartmentId: Helper.MessageAndItsColor(ConsoleColor.Magenta, MessageConstants.EmployeeDepartmentId);
                int departmentId;
                string IdAcceptor = Console.ReadLine();
                if (int.TryParse(IdAcceptor, out departmentId))
                {
                    Employee employee = new();
                    employee.Name = name;
                    employee.Surname = surname;
                    employee.Age = age;
                    employee.Address = address;
                    employee.DepartmentId = departmentId;

                    if (employeeService.Create(employee))
                    {
                        Console.WriteLine($"---{name} {surname} {MessageConstants.EmployeeCreated}---");
                        return;
                    }
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.EmployeeNotCreated);
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.WrongNumber);
                    goto EnterDepartmentId;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateEmployee()
        {
            try
            {
                Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.EmployeeName);
                string? name = Console.ReadLine();
                if (employeeService.GetByName(name) != null)
                {
                    Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.SureMessage);
                    if (SureMessage())
                    {
                        //Employee employee = employeeService.GetByName(name);
                        Employee employee = new();

                        Console.WriteLine("New name");
                        string? newname = Console.ReadLine();
                        if (newname != "")
                        {
                            employee.Name = newname;
                        }
                        Console.WriteLine("New surname");
                        string? newsurname = Console.ReadLine();
                        if (newsurname != "")
                        {
                            employee.Surname = newsurname;
                        }

                        Age: Console.WriteLine("New age");
                        string ageAcceptor = Console.ReadLine();
                        int newage;
                        if (int.TryParse(ageAcceptor, out newage))
                        {
                            employee.Age = newage;
                        }
                        else
                        {
                            if (ageAcceptor != "")
                            {
                                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.SmthngHappenWrong);
                                goto Age;
                            }
                            
                        }

                        Console.WriteLine("New address");
                        string? newaddress = Console.ReadLine();
                        if (newsurname != "")
                        {
                            employee.Address = newaddress;
                        }

                        DepartmentId: Console.WriteLine("New departmentId");
                        string Idaccptor = Console.ReadLine();
                        int newdepartmentId;
                        if (int.TryParse(Idaccptor, out newdepartmentId))
                        {
                            employee.DepartmentId = newdepartmentId;
                        }
                        else
                        {
                            if (Idaccptor != "")
                            {
                                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.SmthngHappenWrong);
                                goto DepartmentId;
                            }
                            else
                            {
                                employee.DepartmentId = employeeService.GetByName(name).DepartmentId;
                            }
                        }


                        
                        if (employeeService.Update(name, employee))
                        {
                            
                            Helper.MessageAndItsColor(ConsoleColor.Green, MessageConstants.EmployeeUpdated);
                        }
                        else
                        {
                            Helper.MessageAndItsColor(ConsoleColor.Red, "EmployeeNotUpdated");
                        }
                        
                        return;
                    }
                    else
                    {
                        Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.ProccessRejected);
                    } 
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.EmployeeNotFind);
                }   
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void GetEmployeeById()
        {
            try
            {
                EmployeeId: Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.EmployeeId);
                int Id;
                string? IdAcceptor = Console.ReadLine();
                if (int.TryParse(IdAcceptor, out Id))
                {
                    if (employeeService.GetById(Id) != null)
                    {
                        FullInfo(employeeService.GetById(Id));
                        return;
                    }
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.EmployeeNotFind);
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.SmthngHappenWrong);
                    goto EmployeeId;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteEmployee()
        {
            Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.EmployeeName);
            string? name = Console.ReadLine();
            Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.SureMessage);
            if (SureMessage())
            {
                if (employeeService.Delete(name))
                {
                    Helper.MessageAndItsColor(ConsoleColor.Green, MessageConstants.DepartmentDelete);
                    return;
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
        public void GetEmployeesByAge()
        {
            Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.EmployeeAge);
            int age;
            string? ageAcceptor = Console.ReadLine();
            if (int.TryParse(ageAcceptor, out age))
            {
                List<Employee> filtered = employeeService.GetAllByAge(age);
                if (filtered.Count != 0)
                {
                    foreach (var item in employeeService.GetAllByAge(age))
                    {
                        FullInfo(item);
                    }
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.EmployeeNotFind);
                }
                
            }
            else
            {
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.SmthngHappenWrong);
            }  
        }
        public void GetEmployeesByDepartmentId()
        {
            Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.EmployeeDepartmentId);
            int departmentId;
            string departmentIdAcceptor = Console.ReadLine();
            if (int.TryParse(departmentIdAcceptor, out departmentId))
            {
                if (employeeService.GetAllByDepartmentId(departmentId).Count > 0)
                {
                    foreach (var item in employeeService.GetAllByDepartmentId(departmentId))
                    {
                        FullInfo(item);
                    }
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.DepartmentNotFind);
                }
                
            }
            else
            {
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.SmthngHappenWrong);
            }   
        }
        public void GetAllEmployeesByDepartmentName()
        {
            try
            {
                Helper.MessageAndItsColor(ConsoleColor.Yellow, MessageConstants.EmployeeDepartmentName);
                string? departmentName = Console.ReadLine();
                Department filteredDepartment = departmentService.Get(dep => dep.Name == departmentName);
                if (employeeService.GetAllByDepartmentId(filteredDepartment.Id) != null)
                {
                    foreach (var item in employeeService.GetAllByDepartmentId(filteredDepartment.Id))
                    {
                        FullInfo(item);
                    }
                    return;
                }
                else
                {
                    Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.EmployeeNotFind);
                } 
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void SearchMethodforEmployeesByNameOrSurname()
        {
            Console.WriteLine("Enter name or surname");
            string? data = Console.ReadLine();
         
    
            List<Employee> nameList = employeeService.SearchMethodforEmployeesByNameOrSurname(e => e.Name == data);
            List<Employee> surnameList = employeeService.SearchMethodforEmployeesByNameOrSurname(e => e.Surname == data);
            if (nameList.Count == 0 && surnameList.Count == 0)
            {
                Helper.MessageAndItsColor(ConsoleColor.Red, MessageConstants.NotFind);
            }
            else
            {
                foreach (var item in nameList)
                {
                    FullInfo(item);
                }
                Console.WriteLine("\n");
                foreach (var item in surnameList)
                {
                    FullInfo(item);
                }
            }
            
        }
        public void GetAllEmployeesCount()
        {
            int count = 0;
            foreach (var item in employeeService.GetAll())
            {
                count++;
            }
            Console.WriteLine($"{MessageConstants.EmployeeCount} {count} \n");  
        }
        private bool SureMessage()
        {
            string? name = Console.ReadLine();
            return name == "Y";
        }
        private void FullInfo(Employee employee)
        {
            Console.WriteLine($" Id - {employee.Id} | name and surname - {employee.Name} {employee.Surname} | adress - {employee.Address} | departmentId - {employee.DepartmentId}");
        }

    }
}
