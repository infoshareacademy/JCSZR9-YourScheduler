using System;
using System.Collections.Generic;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class EventDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Isopen { get; set; }
}
