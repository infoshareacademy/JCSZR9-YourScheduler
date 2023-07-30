using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;
public  class Team
{
    public int TeamId { get; set; }

    public string Name { get; set; } 

    public string Description { get; set; }

    public int AdministratorId { get; set; }

    ICollection<ApplicationUserTeam> ApplicationUsersTeams { get; set; }

    public string PicturePath { get; set; }

}
