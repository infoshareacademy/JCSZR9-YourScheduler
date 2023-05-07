using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models;

public partial class User
{
    
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Displayname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<UsersEvent> UsersEvents { get; } = new List<UsersEvent>();

    public virtual ICollection<UsersTeam> UsersTeams { get; } = new List<UsersTeam>();
}
