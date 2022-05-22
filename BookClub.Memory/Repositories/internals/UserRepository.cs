using BookClub.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Memory.Repositories.internals
{
    public class UserRepository : IUserRepository
    {
        private readonly MainContext _context;

        public UserRepository(MainContext context)
        {
            _context = context;
        }

        public Task<User> AddAndSaveAsync(User entity, CancellationToken cancellationToken = default) =>
            _context.AddAndSaveAsync(entity, cancellationToken);

        public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default) =>
            _context.Users.AsQueryable().ToListAsync(cancellationToken);

        public Task<User> GetUserByName(string name, CancellationToken cancellationToken = default) =>
            _context.Users.AsQueryable().Where(u => u.Name == name).FirstOrDefaultAsync(cancellationToken);


        public Task<User> UpdateAsync(User entity, CancellationToken cancellationToken = default) =>
            _context.UpdateEntityAsync(entity, cancellationToken);

    }
}
