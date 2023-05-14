using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace YourScheduler.Infrastructure.Entities;

public  class ApplicationUser:IdentityUser<int>
{
    
    //public string Id { get; set; }= Guid.NewGuid().ToString();

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Displayname { get; set; } = null!;

    public string Email { get; set; } = null!;

    
   // public string Password { get; set; } = null!;
}
