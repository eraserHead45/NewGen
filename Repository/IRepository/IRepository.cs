using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewGen.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {   
        // T = Employee (class)
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        void Add (T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}