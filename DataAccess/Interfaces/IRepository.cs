using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        bool Create(T obj);
        bool Update(T obj);
        bool Delete(T obj);
        T Get(Predicate<T>predicate);
        List<T> GetAll(Predicate<T>predicate);
    }
}
