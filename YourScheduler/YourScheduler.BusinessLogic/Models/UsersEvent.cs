using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models;

public partial class UsersEvent
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public int EventId { get; set; }

    public virtual EventDto Event { get; set; } = null!;

    public virtual UserDto User { get; set; } = null!;
}
