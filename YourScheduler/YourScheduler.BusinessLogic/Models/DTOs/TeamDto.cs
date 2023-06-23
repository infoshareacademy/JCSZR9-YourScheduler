using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourScheduler.BusinessLogic.Models.DTOs;

public class TeamDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa zespołu' jest obowiązkowe")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Pole 'Opis zespołu' jest obowiązkowe")]
    public string Description { get; set; } = null!;

    public int AdministratorId { get; set; }

    public int LoggedUserId { get; set; }
}
