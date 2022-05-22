using BookClub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Memory.Repositories
{
    public interface IBookUsersRepository : IEntityRepository<BookUsers>
    {
        public Task<List<Book>> GetBooksByUserId(int userId, CancellationToken cancellation = default);
        public void Delete(int userId, int bookId, CancellationToken cancellation = default);

    }
}
