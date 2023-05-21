using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YourScheduler.BusinessLogic.Models;

public  class UserDto:IdentityUser
{

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Displayname { get; set; } = null!;

    public string Email { get; set; } = null!;

    //[DataType(DataType.Password)]
    public string Password { get; set; } = null!;

}
