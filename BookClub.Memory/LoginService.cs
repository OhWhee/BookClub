using BookClub.Memory.Repositories;
using BookClub.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Memory
{
    public class LoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CheckUserNameExists(string username)
        {
            var user = _userRepository.GetUserByName(username).Result;
            return user != null;
        }

        public void CreateUserIfNotExists(string username)
        {
            if (!CheckUserNameExists(username))
                _userRepository.AddAndSaveAsync(new User {Name = username});
        }
    }
}
