using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models;

public class UsersTeam
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual UserDto User { get; set; } = null!;
}
