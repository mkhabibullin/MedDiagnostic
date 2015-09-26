using MedDiagnositc.Entities;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MedDiagnositc.Repositories
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> query);
        Task<TEntity> SingleAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>> query);

        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}
