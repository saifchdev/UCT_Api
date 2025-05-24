using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCCTime_API.Models;

public partial class Timesheet
{
    [Key]   
    public int TimesheetId { get; set; } 

    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }


    public int DisciplineCodeId { get; set; }

    public int StageId { get; set; }

    public virtual Stages ? Stage { get; set; } = null!;  // Add navigation property

    public int TaskId { get; set; }
    public virtual Tasks ? Task { get; set; } = null!;  // Add navigation property

    public DateOnly DateWorked { get; set; }

    public decimal HoursWorked { get; set; }

    public string? Notes { get; set; }

    public string ? Status { get; set; } = null!;


}
