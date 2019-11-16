using FromTheFuture.Domain.Users.FutureItems;
using System;

namespace FromTheFuture.API.FutureItems.CreateUserFutureItem
{
    public class CreateUserFutureItemRequest
    {
        public string Name { get; set; }
        public Uri StorageUri { get; set; }
        public FutureItemTypes ItemType { get; set; }
    }
}
