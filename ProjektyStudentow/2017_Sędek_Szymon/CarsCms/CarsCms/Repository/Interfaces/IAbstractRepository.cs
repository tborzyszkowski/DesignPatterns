using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarsCms.Repository.Interfaces
{
    public interface IAbstractRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        List<T> GetWhere(Expression<Func<T, bool>> expression);
        void Update(T entity);
    }
}