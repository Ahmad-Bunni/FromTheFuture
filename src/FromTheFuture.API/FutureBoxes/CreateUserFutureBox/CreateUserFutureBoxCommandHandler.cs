using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users;
using FromTheFuture.Domain.Users.FutureBoxes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureBoxes.CreateUserFutureBox
{
    public class CreateUserFutureBoxCommandHandler : IRequestHandler<CreateUserFutureBoxCommand, FutureBoxDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserFutureBoxCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<FutureBoxDto> Handle(CreateUserFutureBoxCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            var futureBox = new FutureBox(Guid.NewGuid(), request.Name);

            user.CreateFutureBox(futureBox);

            var result = await _userRepository.CommitAsync();

            return new FutureBoxDto { Id = futureBox.Id, Name = futureBox.Name };

        }
    }
}
