using FromTheFuture.Domain.Users.FutureItems;
using MediatR;
using System;

namespace FromTheFuture.API.FutureItems.Commands.CreateUserFutureItem;

public record CreateUserFutureItemCommand : IRequest<FutureItemDto>
{
    public Guid UserId { get; }
    public string Name { get; }
    public Uri StorageUri { get; }
    public FutureItemTypes ItemType { get; }
    public bool IsActive { get; }

    public CreateUserFutureItemCommand(Guid userId, string name, Uri storageUri, FutureItemTypes itemType, bool isActive)
    {
        UserId = userId;
        Name = name;
        StorageUri = storageUri;
        ItemType = itemType;
        IsActive = isActive;
    }
}

