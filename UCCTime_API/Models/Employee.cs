using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCCTime_API.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    public int? DepartmentId { get; set; }

    public string Position { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? EmployeeCode { get; set; }

    public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();

    public virtual Department? Department { get; set; }

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
