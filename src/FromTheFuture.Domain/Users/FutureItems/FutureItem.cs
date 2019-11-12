using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users.FutureBoxes;
using System.Collections.Generic;

namespace FromTheFuture.Domain.Users.FutureItems
{
    public class FutureItem : BaseEntity
    {
        private readonly List<FutureBoxItem> _futureBoxItems;

        private FutureItem()
        {
            _futureBoxItems = new List<FutureBoxItem>();
        }

        public string Name { get; set; }
        public FutureItemTypes Type { get; set; }
    }



}
