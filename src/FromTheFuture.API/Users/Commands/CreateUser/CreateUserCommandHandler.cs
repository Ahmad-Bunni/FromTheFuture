using System;
using System.Threading;
using System.Threading.Tasks;
using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users;
using MediatR;

namespace FromTheFuture.API.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email);

            await _userRepository.AddUserAsync(user);

            var result = await _userRepository.CommitAsync();

            if (result == CommitResult.Success)
            {
                return new UserDto { Id = user.Id };

            }
            else
            {
                return new UserDto();
            }

        }
    }
}
