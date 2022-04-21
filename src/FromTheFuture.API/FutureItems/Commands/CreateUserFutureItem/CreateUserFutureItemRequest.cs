using FromTheFuture.Domain.Users.FutureItems;
using System;

namespace FromTheFuture.API.FutureItems.Commands.CreateUserFutureItem;

public record CreateUserFutureItemRequest
{
    public string Name { get; init; }
    public bool IsActive { get; init; }
    public Uri StorageUri { get; init; }
    public FutureItemTypes ItemType { get; init; }
}
