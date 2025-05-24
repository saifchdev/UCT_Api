using System;
using System.Collections.Generic;

namespace UCCTime_API.Models;

public partial class Holiday
{
    public int HolidayId { get; set; }

    public DateOnly HolidayDate { get; set; }

    public string Description { get; set; } = null!;
}
