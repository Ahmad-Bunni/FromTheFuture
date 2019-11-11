using System.Collections.Generic;
using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Domain.Users.FutureItems;

namespace FromTheFuture.Domain.Users
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        private readonly List<FutureBox> _futureBoxes;
        private readonly List<FutureItem> _futureItems;

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        private User()
        {
            _futureBoxes = new List<FutureBox>();
            _futureItems = new List<FutureItem>();
        }

        public void CreateFutureBox(FutureBox box)
        {
            _futureBoxes.Add(box);
        }

        public void CreateFutureItem(FutureItem item)
        {
            _futureItems.Add(item);
        }
    }
}
