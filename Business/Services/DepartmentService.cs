using Business.Interfaces;
using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DepartmentService : IDepartment
    {
        public static int Id { get; set; }
        DepartmentReposity departmentReposity { get; set; }

        public DepartmentService()
        {
            departmentReposity = new DepartmentReposity();
        }

        public void Create(Department department)
        {
            try
            {
                if (departmentReposity.Get(emp => emp.Name == department.Name) == null)
                {
                    departmentReposity.Create(department);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
