using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users.FutureBoxes;
using System;
using System.Collections.Generic;

namespace FromTheFuture.Domain.Users.FutureItems
{
    public class FutureItem : BaseEntity
    {
        public string Name { get; private set; }
        public Uri StorageUri { get; private set; }
        public FutureItemTypes ItemType { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<FutureBoxItem> _futureBoxItems;

        private FutureItem()
        {
            _futureBoxItems = new List<FutureBoxItem>();
        }

        public FutureItem(Guid id, string name, Uri storageUri, FutureItemTypes itemType, bool isActive)
        {
            Id = id;
            Name = name;
            StorageUri = storageUri;
            ItemType = itemType;
            IsActive = isActive;
        }

        public void Modify(string name, Uri storageUri, FutureItemTypes itemType, bool isActive)
        {
            Name = name;
            StorageUri = storageUri;
            ItemType = itemType;
            IsActive = isActive;
        }
    }



}
