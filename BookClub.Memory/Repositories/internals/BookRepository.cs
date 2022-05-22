using BookClub.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookClub.Memory.Repositories.internals
{
    public class BookRepository : IBookRepository
    {
        private readonly MainContext _context;

        public BookRepository(MainContext context)
        {
            _context = context;
        }

        public Task<Book> AddAndSaveAsync(Book entity, CancellationToken cancellationToken = default) =>
            _context.AddAndSaveAsync(entity, cancellationToken);


        public Task<List<Book>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _context.Books.AsQueryable().ToListAsync(cancellationToken);

        public Task<Book> GetBookById(int Id, CancellationToken cancellationToken = default) =>
            _context.Books.AsQueryable().Where(b=>b.BookId == Id).SingleOrDefaultAsync(cancellationToken);


        public Task<Book> UpdateAsync(Book entity, CancellationToken cancellationToken = default) =>
            _context.UpdateEntityAsync(entity, cancellationToken);

    }
}
