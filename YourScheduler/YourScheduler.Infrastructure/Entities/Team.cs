using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;
public  class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserTeam> UsersTeams { get; } = new List<UserTeam>();
}
