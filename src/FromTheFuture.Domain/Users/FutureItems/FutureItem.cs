using FromTheFuture.Domain.Shared;

namespace FromTheFuture.Domain.Users.FutureItems
{
    public class FutureItem : BaseEntity
    {
        public string Name { get; set; }
        public FutureItemTypes Type { get; set; }
    }

}
