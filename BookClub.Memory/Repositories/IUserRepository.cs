using BookClub.Memory.Repositories;
using BookClub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Memory.Repositories
{
    public interface IUserRepository : IEntityRepository<User>
    {
        public Task<User> GetUserByName(string Name, CancellationToken cancellationToken = default);
    }
}
