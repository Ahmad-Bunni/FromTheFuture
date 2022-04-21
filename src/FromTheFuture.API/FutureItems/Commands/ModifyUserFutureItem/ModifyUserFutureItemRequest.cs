using FromTheFuture.Domain.Users.FutureItems;
using System;

namespace FromTheFuture.API.FutureItems.Commands.ModifyUserFutureItem;

public record ModifyUserFutureItemRequest
{
    public string Name { get; init; }
    public Uri StorageUri { get; init; }
    public FutureItemTypes ItemType { get; init; }
    public bool IsActive { get; init; }
}
