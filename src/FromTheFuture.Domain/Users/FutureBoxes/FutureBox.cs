using FromTheFuture.Domain.Shared;
using System;
using System.Collections.Generic;

namespace FromTheFuture.Domain.Users.FutureBoxes;

public class FutureBox : BaseEntity
{
    public string Name { get; private set; }

    private ICollection<FutureBoxItem> _futureBoxItems;

    private FutureBox()
    {
        _futureBoxItems = new List<FutureBoxItem>();
    }

    public FutureBox(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Modify(string name, ICollection<FutureBoxItem> futureBoxItems)
    {
        Name = name;

        _futureBoxItems = futureBoxItems;
    }
}
