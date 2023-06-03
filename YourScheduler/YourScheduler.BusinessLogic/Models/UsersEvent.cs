using System;
using System.Collections.Generic;
using YourScheduler.BusinessLogic.Models.DTOs;

namespace YourScheduler.BusinessLogic.Models;

public  class UsersEvent
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EventId { get; set; }

    public virtual EventDto Event { get; set; } = null!;

    public virtual UserDto User { get; set; } = null!;
}
