using MedDiagnositc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MedDiagnositc.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Find(params object[] keyValues);
        TEntity Single(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void InsertGraphRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);
        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);
        IQueryFluent<TEntity> Query();
        IQueryable<TEntity> Queryable();
        IRepository<T> GetRepository<T>() where T : Entity;
    }
}
