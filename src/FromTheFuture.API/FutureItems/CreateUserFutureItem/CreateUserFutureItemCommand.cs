using FromTheFuture.Domain.Users.FutureItems;
using MediatR;
using System;

namespace FromTheFuture.API.FutureItems.CreateUserFutureItem
{
    public class CreateUserFutureItemCommand : IRequest<FutureItemDto>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public Uri StorageUri { get; set; }
        public FutureItemTypes ItemType { get; set; }

        public CreateUserFutureItemCommand(Guid userId, string name, Uri storageUri, FutureItemTypes itemType)
        {
            UserId = userId;
            Name = name;
            StorageUri = storageUri;
            ItemType = itemType;
        }
    }

}
