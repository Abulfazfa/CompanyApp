using DataAccess.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeReposity : IRepository<Employee>
    {
        public bool Create(Employee obj)
        {
            try
            {
                DBContext.Employees.Add(obj);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Delete(Employee obj)
        {
            try
            {
                DBContext.Employees.Remove(obj);
                return true;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public Employee Get(Predicate<Employee> predicate)
        {
            try
            {
                return DBContext.Employees.Find(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Employee> GetAll(Predicate<Employee>predicate = null)
        {
            try
            {            
                return predicate == null ? DBContext.Employees: DBContext.Employees.FindAll(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Employee obj)
        {
            try
            {
                Employee employee = Get(emp => emp.Id == obj.Id);
                if (employee != null)
                {
                    employee = obj;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
