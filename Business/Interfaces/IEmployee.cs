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
        void Create(Employee employee);
        void Update(int id);
        void Delete(int id);
        Employee GetById(int id);
        Employee GetByAge(int age);
        Employee GetByDepartmentId(int departmentId);
        List<Employee> GetAll();
    }
}
