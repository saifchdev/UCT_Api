using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCCTime_API.Models;

public partial class Tasks
{
    [Key]
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
