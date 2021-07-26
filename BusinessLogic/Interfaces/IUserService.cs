using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> AddUser(User user);
        public Task<bool> DeleteUserById(Guid id);
        public User GetUserById(Guid id);
        public IEnumerable<User> GetUsers();
        public Task<bool> PutUser(User user);
    }
}
