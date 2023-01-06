using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEmployee
    {
        bool Create(Employee employee);
        bool Update(string name, Employee employee);
        bool Delete(string name);
        Employee GetById(int id);
        List<Employee> GetAllByAge(int age);
        List<Employee> GetAllByDepartmentId(int departmentId);
        List<Employee> GetAll(Predicate<Employee>predicate);
    }
}
