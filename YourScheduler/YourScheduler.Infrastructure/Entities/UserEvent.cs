using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;

public partial class UserEvent
{
    public int UserEventId { get; set; }

    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public int ApplicationUserId { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
