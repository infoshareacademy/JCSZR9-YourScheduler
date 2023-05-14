using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;

public partial class UserTeam
{
    public int UserTeamId { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public int ApplicationUserId { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
