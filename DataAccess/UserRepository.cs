using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions<UsersDBContext> _options;
        public UserRepository(DbContextOptions<UsersDBContext> options)
        {
            _options = options;
        }
        public async Task<Guid> AddUser(UserDTO user)
        {
            using (var context = new UsersDBContext(_options))
            {
                try
                {
                    await context.AddAsync(user);
                    await context.SaveChangesAsync();
                    return user.Id;
                }
                catch(Exception)
                {
                    return Guid.Empty;
                }
                
            }
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            using (var context = new UsersDBContext(_options))
            {
                try
                {
                    var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                    return user;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            using (var context = new UsersDBContext(_options))
            {
                try
                {
                    var users = context.Users.ToList();
                    return users;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<bool> PutUser(UserDTO user)
        {
            using (var context = new UsersDBContext(_options))
            {
                try
                {
                    var foundUser = await context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                    foundUser.ChangeFields(user);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteUserById(Guid id)
        {
            using (var context = new UsersDBContext(_options))
            {
                try
                {
                    var userToDelete = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                    context.Users.Remove(userToDelete);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }
    }
}
