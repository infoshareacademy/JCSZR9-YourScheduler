using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class ApplicationUserDto : IdentityUser<int>
{

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Displayname { get; set; } = null!;

}
