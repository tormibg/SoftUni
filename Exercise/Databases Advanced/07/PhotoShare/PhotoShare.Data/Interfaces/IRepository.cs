using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PhotoShare.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicat);

        TEntity FirstOrDefault();

        TEntity FirstOrDefaultWhere(Expression<Func<TEntity, bool>>  predicat);
    }
}
