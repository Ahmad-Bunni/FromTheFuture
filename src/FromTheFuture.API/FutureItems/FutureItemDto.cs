﻿using FromTheFuture.Domain.Users.FutureItems;
using System;

namespace FromTheFuture.API.FutureItems
{
    public class FutureItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Uri StorageUri { get; set; }
        public FutureItemTypes ItemType { get; set; }
    }
}
