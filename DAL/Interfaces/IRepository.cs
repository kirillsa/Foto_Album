using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        void Create(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(T item);
        void Delete(int id);
        //IEnumerable<T> Find(Func<T, bool> predicate);
    }
}
