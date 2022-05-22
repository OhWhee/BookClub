using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClub.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClub.Memory.Repositories.internals
{
    public class BookUsersRepository : IBookUsersRepository
    {
        private readonly MainContext _context;

        public BookUsersRepository(MainContext context)
        {
            _context = context;
        }
       
        public Task<BookUsers> AddAndSaveAsync(BookUsers entity, CancellationToken cancellationToken = default) =>
            _context.AddAndSaveAsync(entity, cancellationToken);

        public void Delete(int userId, int bookId, CancellationToken cancellation = default) 
        {
            var item = _context.BookUsers.AsQueryable().FirstOrDefaultAsync(b => b.UserId == userId && b.BookId == bookId).Result;
            if (item != null)
            {
                _context.BookUsers.Remove(item);
                _context.SaveChanges();
            }
                
        }

        public Task<List<BookUsers>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _context.BookUsers.AsQueryable().ToListAsync(cancellationToken);

        public Task<List<Book>> GetBooksByUserId(int userId, CancellationToken cancellation = default) =>
            _context.BookUsers.AsQueryable()
            .Where(x => x.UserId == userId)
            .Select(b => b.Book)
            .ToListAsync();
                   

        public Task<BookUsers> UpdateAsync(BookUsers entity, CancellationToken cancellationToken = default) =>
            _context.UpdateEntityAsync(entity, cancellationToken);

    }
}
