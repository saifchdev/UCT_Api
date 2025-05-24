using System;
using System.Collections.Generic;

namespace UCCTime_API.Models;

public partial class Approval
{
    public int ApprovalId { get; set; }

    public int TimesheetId { get; set; }

    public int ApprovedBy { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Comments { get; set; }

    public virtual Employee ApprovedByNavigation { get; set; } = null!;

    public virtual Timesheet Timesheet { get; set; } = null!;
}
