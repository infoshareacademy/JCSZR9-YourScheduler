using System;
using System.Collections.Generic;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Models;

public class UsersTeam
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TeamId { get; set; }

    public virtual TeamDto Team { get; set; } = null!;

    public virtual UserDto User { get; set; } = null!;
}
