using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDepartment
    {
        void Create(Department department);
        void Update(int id);
        void Delete(string name);
        Department GetById(int id);
        List<Department> GetAll();
    }
}
