
using BookClub.Models.Entities;

namespace BookClub.Memory.Repositories
{
    public interface IBookRepository : IEntityRepository<Book>
    {
        public Task<Book> GetBookById(int Id, CancellationToken cancellationToken = default);
    }
}
