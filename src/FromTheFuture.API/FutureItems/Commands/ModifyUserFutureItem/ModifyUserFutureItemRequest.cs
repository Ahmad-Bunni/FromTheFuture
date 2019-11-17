using FromTheFuture.Domain.Users.FutureItems;
using System;

namespace FromTheFuture.API.FutureItems.Commands.ModifyUserFutureItem
{
    public class ModifyUserFutureItemRequest
    {
        public string Name { get; set; }
        public Uri StorageUri { get; set; }
        public FutureItemTypes ItemType { get; set; }
        public bool IsActive { get; set; }
    }
}
