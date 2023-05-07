﻿using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UsersTeam> UsersTeams { get; } = new List<UsersTeam>();
}
