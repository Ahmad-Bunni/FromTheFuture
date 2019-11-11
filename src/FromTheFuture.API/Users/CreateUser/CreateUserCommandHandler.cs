using System;
using System.Threading;
using System.Threading.Tasks;
using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users;
using MediatR;

namespace FromTheFuture.API.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email);

            await _userRepository.CreateUser(user);

            var result = await _unitOfWork.CommitAsync();

            if (result.IsSuccessful)
            {
                return new UserDto { Id = user.Id };

            }
            else
            {
                throw result.Exception;
            }

        }
    }
}
