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
        public EmployeeService()
        {
            employeeRepository = new EmployeeReposity();
        }
        public void Create(Employee employee)
        {
            try
            {
                if (employeeRepository.Get(emp => emp.Name.ToLower() == employee.Name.ToLower()) == null)
                {
                    employeeRepository.Create(employee);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
        public void Delete(int id)
        {
            Employee? deletedEmployee = DBContext.Employees.Find(emp => emp.Id == id);
            employeeRepository.Delete(deletedEmployee);
        }
        public List<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }
        public Employee GetByAge(int age)
        {
            return employeeRepository.Get(emp => emp.Age == age);
        }
        public Employee GetByDepartmentId(int id)
        {
            return employeeRepository.Get(emp => emp.DepartmentId == id);
        }
        public Employee GetById(int id)
        {
            return employeeRepository.Get(emp => emp.Id == id);
        }
        public void Update(int id)
        {
            Employee filtered = employeeRepository.Get(emp => emp.Id == id);
            employeeRepository.Update(filtered);
        }
    }
}
