using System;
using System.Collections.Generic;

namespace MVC_project.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? EventId { get; set; }

    public DateOnly? ScheduleDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? Activity { get; set; }

    public virtual Event1? Event { get; set; }
}
