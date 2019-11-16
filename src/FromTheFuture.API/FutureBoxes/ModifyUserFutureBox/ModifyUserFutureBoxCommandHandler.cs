using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users;
using FromTheFuture.Domain.Users.FutureBoxes;
using MediatR;

namespace FromTheFuture.API.FutureBoxes.ModifyUserFutureBox
{
    public class ModifyUserFutureBoxCommandHandler : IRequestHandler<ModifyUserFutureBoxCommand>
    {
        private readonly IUserRepository _userRepository;

        public ModifyUserFutureBoxCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(ModifyUserFutureBoxCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserDetailsAsync(request.UserId);

            var futureBoxItems = request.FutureItemsIds?.Select(x => new FutureBoxItem { FutureBoxId = request.BoxId, FutureItemId = x }).ToList();

            user.ModifyFutureBox(request.BoxId, request.Name, futureBoxItems);

            var result = await _userRepository.CommitAsync();

            return await Unit.Task;
        }
    }
}
