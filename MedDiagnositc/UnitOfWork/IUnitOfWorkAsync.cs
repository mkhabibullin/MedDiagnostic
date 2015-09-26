using MedDiagnositc.Entities;
using MedDiagnositc.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MedDiagnositc.UnitOfWork
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<TEntity> RepositoryAsync<TEntity>() where TEntity : Entity;
    }
}
