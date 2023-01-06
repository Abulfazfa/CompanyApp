using Business.Interfaces;
using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public bool Create(Department department)
        {
            try
            {
                if (departmentReposity.Get(dep => dep.Name == department.Name) == null)
                {
                    departmentReposity.Create(department);
                    return true;
                }
                return false;              
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool Update(string name, Department department)
        {
            try
            {
                Department filtereddepartment = departmentReposity.Get(dep => dep.Name == name);
                if (department.Name != name)
                {
                    Department isAvaible = departmentReposity.Get(dep => dep.Name == department.Name);
                    if (isAvaible == null)
                    {
                        if (department.Name != null)
                        {
                            filtereddepartment.Name = department.Name;
                        }
                        if (department.Capasity != 0)
                        {
                            filtereddepartment.Capasity = department.Capasity;
                        }

                        departmentReposity.Update(filtereddepartment);
                        return true;

                    }
                    return false;
                }
                else
                {
                    if (department.Capasity != 0)
                    {
                        filtereddepartment.Capasity = department.Capasity;
                    }

                    departmentReposity.Update(filtereddepartment);
                    return true;
                }
               
                   
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(string name)
        {
            if (departmentReposity.Get(dep => dep.Name == name) != null)
            {
                departmentReposity.Delete(departmentReposity.Get(dep => dep.Name == name));
                return true;
            }
            return false;
        }

        public Department GetById(int id)
        {
            if (departmentReposity.Get(dep => dep.Id == id) != null)
            {               
                return departmentReposity.Get(dep => dep.Id == id);
            }
            return null;
        }
        public Department Get(Predicate<Department> predicate)
        {
            return departmentReposity.Get(predicate);
        }

        public List<Department> GetAll()
        {
            return departmentReposity.GetAll();
        }
        public List<Department> SearchMethodforDepartments(Predicate<Department> predicate)
        {
            return departmentReposity.GetAll(predicate);
        }
    }
}
