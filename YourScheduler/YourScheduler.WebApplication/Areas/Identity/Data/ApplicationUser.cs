using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YourScheduler.BusinessLogic;

namespace YourScheduler.WebApplication.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string DisplayName { get; set; }

}

