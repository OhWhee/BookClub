using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Memory.Repositories
{
    public interface IEntityRepository<T>
    {
        public Task<T> AddAndSaveAsync(T entity, CancellationToken cancellationToken = default);
        public Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        public Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
