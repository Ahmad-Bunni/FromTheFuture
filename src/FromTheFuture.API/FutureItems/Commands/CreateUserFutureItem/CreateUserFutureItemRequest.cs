using FromTheFuture.Domain.Users.FutureItems;
using System;

namespace FromTheFuture.API.FutureItems.Commands.CreateUserFutureItem
{
    public class CreateUserFutureItemRequest
    {
        public string Name { get; set; }
        public Uri StorageUri { get; set; }
        public FutureItemTypes ItemType { get; set; }

        public bool IsActive { get; set; }
    }
}
