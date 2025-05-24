using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCCTime_API.Models;

public partial class Project
{
    [Key]
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string ProjectCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
