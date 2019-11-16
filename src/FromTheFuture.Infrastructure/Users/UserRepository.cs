using FromTheFuture.Domain.Users;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FromTheFuture.Infrastructure.Helpers;

namespace FromTheFuture.Infrastructure.Users
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly FutureDbContext _context;
        public UserRepository(FutureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<User> GetUserDetailsAsync(Guid Id)
        {
            return await _context.Users
               .IncludePaths(TableNavigationPaths.FutureBoxTable, TableNavigationPaths.FutureBoxItemTable)
               .Include(TableNavigationPaths.FutureItemTable)
               .FirstOrDefaultAsync(x => x.Id == Id);
        }
    }

}
