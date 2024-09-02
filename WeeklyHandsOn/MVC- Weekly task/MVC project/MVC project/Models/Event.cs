﻿using System;
using System.Collections.Generic;

namespace MVC_project.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public DateOnly? EventDate { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }
}
