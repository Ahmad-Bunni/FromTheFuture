using FromTheFuture.Domain.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FromTheFuture.API.FutureItems.Commands.ModifyUserFutureItem;

public class ModifyUserFutureItemCommandHandler : IRequestHandler<ModifyUserFutureItemCommand, FutureItemDto>
{
    private readonly IUserRepository _userRepository;

    public ModifyUserFutureItemCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<FutureItemDto> Handle(ModifyUserFutureItemCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserDetailsAsync(request.UserId);

        user.ModifyFutureItem(request.ItemId, request.Name, request.StorageUri, request.ItemType, request.IsActive);

        var _ = await _userRepository.CommitAsync();

        return new FutureItemDto();
    }
}
