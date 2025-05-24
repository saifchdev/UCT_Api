using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCCTime_API.Models;

public partial class Stages
{
    [Key]
    public int StageId { get; set; }

    public string StageName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
