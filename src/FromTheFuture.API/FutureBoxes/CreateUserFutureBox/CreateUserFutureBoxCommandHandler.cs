using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users;
using FromTheFuture.Domain.Users.FutureBoxes;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureBoxes.CreateUserFutureBox
{
    public class CreateUserFutureBoxCommandHandler : IRequestHandler<CreateUserFutureBoxCommand, FutureBoxDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserFutureBoxCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<FutureBoxDto> Handle(CreateUserFutureBoxCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            var futureBox = new FutureBox(request.Name, Guid.NewGuid());

            var futureBoxItems = request.FutureItems.Select(x => new FutureBoxItem
            {
                FutureBoxId = futureBox.Id,
                FutureItemId = x.Id

            }).ToList();

            futureBox.AddFutureBoxItems(futureBoxItems);

            user.CreateFutureBox(futureBox);

            var result = await _unitOfWork.CommitAsync();

            if (result.IsSuccessful)
            {
                return new FutureBoxDto { Id = futureBox.Id };
            }
            else
            {
                throw result.Exception;
            }
        }
    }
}
