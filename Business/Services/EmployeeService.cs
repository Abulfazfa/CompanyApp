using Business.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeService : IEmployee 
    {
     
        private readonly EmployeeReposity employeeRepository;
        private readonly DepartmentReposity departmentReposity;
        public EmployeeService()
        {
            employeeRepository = new EmployeeReposity();
            departmentReposity = new DepartmentReposity();
        }
        public bool Create(Employee employee)
        {
            try
            {
                if (employeeRepository.Get(emp => emp.Name.ToLower() == employee.Name.ToLower()) == null)
                {
                    Department filtered = departmentReposity.Get(dep => dep.Id == employee.DepartmentId);
                    if (filtered != null)
                    {
                        filtered.MemberCount++;
                    }
                    else
                    {
                        Console.WriteLine("There is no such department ");
                        return false;
                    }
                    
                    if (filtered.MemberCount <= filtered.Capasity)
                    {
                        return employeeRepository.Create(employee);
                    }
                    else
                    {
                        Console.WriteLine("You exceeded the capacity limit");
                        return false;
                    }
                    
                }
                else
                {
                    Console.WriteLine("There is already a employee with that name and surname");
                    return false;
                }
                
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool Delete(string name)
        {
            try
            {
                Employee? deletedEmployee = employeeRepository.Get(emp => emp.Name.ToLower() == name.ToLower());
                Department department = departmentReposity.Get(dep => dep.Id == deletedEmployee.DepartmentId);
                if (deletedEmployee != null)
                {
                    department.MemberCount--;
                    return employeeRepository.Delete(deletedEmployee);
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            } 
        }
       
        public List<Employee> GetAll(Predicate<Employee>predicate = null)
        {
            return employeeRepository.GetAll(predicate);
        }
        public List<Employee> GetAllByAge(int age)
        {
            return employeeRepository.GetAll(emp => emp.Age == age);
        }
        public Employee GetById(int id)
        {
            return employeeRepository.Get(emp => emp.Id == id);
        }
        public Employee GetByName(string name)
        {
            return employeeRepository.Get(emp => emp.Name == name);
        }
        public List<Employee> GetAllByDepartmentId(int id)
        {
            return employeeRepository.GetAll(emp => emp.DepartmentId == id);
        }
        public List<Employee> SearchMethodforEmployeesByNameOrSurname(Predicate<Employee> predicate)
        {
            return employeeRepository.GetAll(predicate);
        }

        public bool Update(string name, Employee employee)
        {
            try
            {
                Employee filtered = employeeRepository.Get(emp => emp.Name.ToLower() == name.ToLower());
                Department department = departmentReposity.Get(dep => dep.Id == filtered.DepartmentId);
               
                if (filtered.DepartmentId != employee.DepartmentId)
                {
                    Department department1 = departmentReposity.Get(dep => dep.Id == employee.DepartmentId);
                    if (department1 != null)
                    {
                        if (employee.Name != null)
                        {
                            filtered.Name = employee.Name;
                        }
                        if (employee.Surname != null)
                        {
                            filtered.Surname = employee.Surname;
                        }
                        if (employee.Age != 0)
                        {
                            filtered.Age = employee.Age;
                        }
                        if (employee.Address != null)
                        {
                            filtered.Address = employee.Address;
                        }
                        if (employee.DepartmentId != 0)
                        {
                            if (department1.MemberCount + 1 <= department1.Capasity)
                            {
                                department.MemberCount--;
                                department1.MemberCount++;

                                filtered.DepartmentId = employee.DepartmentId;
                            }
                            Console.WriteLine("You");
                            return false;
                        }
                        employeeRepository.Update(filtered);
                        return true;

                    }
                    return false;
                    
                }
                else
                {
                    if (employee.Name != null)
                    {
                        filtered.Name = employee.Name;
                    }
                    if (employee.Surname != null)
                    {
                        filtered.Surname = employee.Surname;
                    }
                    if (employee.Age != 0)
                    {
                        filtered.Age = employee.Age;
                    }
                    if (employee.Address != null)
                    {
                        filtered.Address = employee.Address;
                    }
                    employeeRepository.Update(filtered);
                    return true;
                }
                

                    
                
               
            }
            catch (Exception)
            {
                throw;
            }
           
           
        } 
      
    }
}
