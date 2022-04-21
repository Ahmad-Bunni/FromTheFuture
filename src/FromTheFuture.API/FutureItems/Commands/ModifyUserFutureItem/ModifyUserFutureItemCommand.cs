using FromTheFuture.Domain.Users.FutureItems;
using MediatR;
using System;

namespace FromTheFuture.API.FutureItems.Commands.ModifyUserFutureItem;

public record ModifyUserFutureItemCommand : IRequest<FutureItemDto>
{
    public Guid ItemId { get; }
    public Guid UserId { get; }
    public string Name { get; }
    public bool IsActive { get; }
    public Uri StorageUri { get; }
    public FutureItemTypes ItemType { get; }

    public ModifyUserFutureItemCommand(Guid itemId, Guid userId, string name, Uri storageUri, FutureItemTypes itemType, bool isActive)
    {
        ItemId = itemId;
        UserId = userId;
        Name = name;
        StorageUri = storageUri;
        ItemType = itemType;
        IsActive = isActive;
    }
}
