using System.ComponentModel.DataAnnotations;

namespace UCCTime_API.Models
{
    public class TimesheetpostDTO
    {
        [Key]
        public int TimesheetID { get; set; }
        public int ProjectID { get; set; }
        public int DisciplineCodeID { get; set; }

        public int StageID { get; set; }

        public int TaskID { get; set; }
        public DateOnly dateWorked { get; set; }
        public decimal HoursWorked { get; set; }
        public string notes { get; set; }
  
     
   


    }
}
