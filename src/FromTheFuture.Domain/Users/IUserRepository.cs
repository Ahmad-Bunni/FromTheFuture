using FromTheFuture.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace FromTheFuture.Domain.Users
{
    public interface IUserRepository
    {
        Task CreateUser(User user);

        Task<User> GetUserByIdAsync(Guid Id);
    }
}
