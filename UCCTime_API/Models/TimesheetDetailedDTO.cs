namespace UCCTime_API.Models
{
    public class TimesheetDetailedDTO
    {
        public int TimesheetID { get; set; }
        public string ProjectName { get; set; }
        public string Country { get; set; }
        public string ProjectCode { get; set; }
        public DateOnly dateWorked { get; set; }
        public decimal HoursWorked { get; set; }
        public string notes { get; set; }
        public int DisciplineCodeID { get; set; }
        public string DisciplineName { get; set; }
        public int StageID { get; set; }

        public string StageName { get; set; }
        public int TaskID { get; set; }

        public string TaskName { get; set; }
        public int DayOfWeek { get; set; }




    }
}
