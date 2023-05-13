using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models;

public partial class UsersTeam
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual UserDto User { get; set; } = null!;
}
