using FromTheFuture.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace FromTheFuture.Domain.Users;

public interface IUserRepository : IBaseRepository
{
    Task AddUserAsync(User user);
    Task<User> GetUserByIdAsync(Guid Id);
    Task<User> GetUserDetailsAsync(Guid Id);
}
