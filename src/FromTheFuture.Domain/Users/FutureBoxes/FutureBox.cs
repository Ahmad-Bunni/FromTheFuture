using FromTheFuture.Domain.Shared;
using System;
using System.Collections.Generic;

namespace FromTheFuture.Domain.Users.FutureBoxes
{
    public class FutureBox : BaseEntity
    {
        public string Name { get; set; }

        private readonly List<FutureBoxItem> _futureBoxItems;

        private FutureBox()
        {
            _futureBoxItems = new List<FutureBoxItem>();
        }

        public FutureBox(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public void AddFutureBoxItems(List<FutureBoxItem> futureBoxItems)
        {
            if (futureBoxItems.Count > 0)
                _futureBoxItems.AddRange(futureBoxItems);
        }

    }
}
