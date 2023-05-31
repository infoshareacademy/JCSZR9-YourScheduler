﻿using System;
using System.Collections.Generic;

namespace YourScheduler.Infrastructure.Entities;

public  class Event
{
    public int  EventId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool IsOpen { get; set; }

    public int administratorId { get; set; }

    ICollection<ApplicationUserEvent> ApplicationUsersEvents { get; set; }
}
