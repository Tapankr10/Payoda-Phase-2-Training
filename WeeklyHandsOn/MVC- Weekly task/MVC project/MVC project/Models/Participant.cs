using System;
using System.Collections.Generic;

namespace MVC_project.Models;

public partial class Participant
{
    public int ParticipantId { get; set; }

    public int? EventId { get; set; }

    public string? ParticipantName { get; set; }

    public string? Email { get; set; }

    public string? ContactNumber { get; set; }

    public virtual Event1? Event { get; set; }
}
