using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCCTime_API.Models;

public partial class DisciplineCode
{
    [Key]
    public int DisciplineCodeId { get; set; }

    public string DisciplineName { get; set; } = null!;

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
