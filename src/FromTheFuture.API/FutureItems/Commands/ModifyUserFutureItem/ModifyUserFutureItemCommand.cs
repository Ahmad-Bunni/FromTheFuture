using FromTheFuture.Domain.Users.FutureItems;
using MediatR;
using System;

namespace FromTheFuture.API.FutureItems.Commands.ModifyUserFutureItem
{
    public class ModifyUserFutureItemCommand : IRequest<FutureItemDto>
    {
        public Guid ItemId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Uri StorageUri { get; set; }
        public FutureItemTypes ItemType { get; set; }

        public bool IsActive { get; set; }

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
}
