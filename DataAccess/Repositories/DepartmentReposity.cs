using DataAccess.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class DepartmentReposity : IRepository<Department>
    {
        public bool Create(Department obj)
        {
            try
            {
               DBContext.Departments.Add(obj);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Department obj)
        {
            try
            {
                DBContext.Departments.Remove(obj);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Department Get(Predicate<Department> predicate)
        {
            try
            {
                return DBContext.Departments.Find(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Department> GetAll(Predicate<Department> predicate = null)
        {
            try
            {
                return predicate == null ? DBContext.Departments : DBContext.Departments.FindAll(predicate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Department obj)
        {
            Department department = Get(department => department.Id == obj.Id);
            if (department != null)
            {
                department = obj;
                return true;
            }
            return false;
        }
    }
}
