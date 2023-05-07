using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Isopen { get; set; }

    public virtual ICollection<UsersEvent> UsersEvents { get; } = new List<UsersEvent>();
}
