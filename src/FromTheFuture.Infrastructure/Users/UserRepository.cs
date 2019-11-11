using FromTheFuture.Domain.Users;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.Internal;
using FromTheFuture.Infrastructure.SeedWork;

namespace FromTheFuture.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly FutureDbContext _context;
        public UserRepository(FutureDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            return await _context.Users
                .IncludePaths(
                UserEntityTypeConfiguration.FutureBoxes,
                UserEntityTypeConfiguration.FutureItems,
                UserEntityTypeConfiguration.FutureBoxItems)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }


    }

}
