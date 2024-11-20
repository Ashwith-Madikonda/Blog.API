using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Blog.Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> Delete(Guid id);
        void RemoveRange(ICollection<TEntity> entities);
    }
}
