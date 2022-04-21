using FromTheFuture.Domain.Shared;
using FromTheFuture.Domain.Users.FutureBoxes;
using FromTheFuture.Domain.Users.FutureItems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FromTheFuture.Domain.Users;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }

    private readonly ICollection<FutureBox> _futureBoxes;
    private readonly ICollection<FutureItem> _futureItems;

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

    public void ModifyFutureBox(Guid boxId, string name, ICollection<FutureBoxItem> futureBoxItems)
    {
        var futureBox = _futureBoxes.SingleOrDefault(x => x.Id == boxId);

        futureBox.Modify(name, futureBoxItems);

    }

    public void ModifyFutureItem(Guid itemId, string name, Uri storageUri, FutureItemTypes itemType, bool isActive)
    {
        var futureItem = _futureItems.SingleOrDefault(x => x.Id == itemId);

        futureItem.Modify(name, storageUri, itemType, isActive);
    }
}
