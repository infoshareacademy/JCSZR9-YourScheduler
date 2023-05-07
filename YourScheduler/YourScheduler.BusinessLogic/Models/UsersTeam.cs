using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models;

public partial class UsersTeam
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
