using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class EventDto
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Pole 'Nazwa wydarzenia' jest obowiązkowe")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Pole 'Opis wydarzenia' jest obowiązkowe")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Pole 'Data' jest obowiązkowe")]
    public DateTime Date { get; set; }

    public bool Isopen { get; set; }

    public int administratorId { get; set; }
}
