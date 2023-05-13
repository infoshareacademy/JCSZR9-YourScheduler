using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;

public partial class UserTeam
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;
}
