using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace YourScheduler.Infrastructure.Entities;

public  class ApplicationUser:IdentityUser<int>
{
    
    //public string Id { get; set; }= Guid.NewGuid().ToString();

  //  public string ApplicationUserId { get; set; }

    public string Name { get; set; } 

    public string Surname { get; set; } 

    public string Displayname { get; set; }

    public string Email { get; set; } 

    public ICollection<ApplicationUserEvent> ApplicationUsersEvents { get; set; }

    public ICollection<ApplicationUserTeam> ApplicationUsersTeams { get; set; }   
    
   // public string Password { get; set; } = null!;
}
