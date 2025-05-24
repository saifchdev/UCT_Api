using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UCCTime_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.Data.SqlClient;


namespace UCCTime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly UccdataContext _context;

        public TimesheetController(UccdataContext context)
        {
            _context = context;
        }

        // GET: api/Timesheet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timesheet>>> GetTimesheet()
        {
            return await _context.Timesheets.ToListAsync();
        }

      

        // GET: api/Timesheet/5
        [HttpGet("{weekStart}")]
        public async Task<ActionResult<Timesheet>> GetTimesheetByDate(DateTime weekStart)
        {
            //DateOnly startDate = 
           // DateOnly endDate =;
           // int empID = 3;

            var startDate = new SqlParameter("@startDate", DateOnly.FromDateTime(weekStart));
            var endDate = new SqlParameter("@endDate", DateOnly.FromDateTime(weekStart).AddDays(7));

            var empID = new SqlParameter("@employeeID", 3);

            var filteredData =_context.timeSheetDTO.FromSqlRaw("EXEC get_SummarisedData @startDate,@endDate,@employeeID", startDate,endDate,empID).ToList();
          


            if (!filteredData.Any())
            {
                return NotFound($"No timesheet data found for week starting {weekStart}.");
            }

            return Ok(filteredData);
        }


        // GET: api/Timesheet/GetData
        [HttpGet("GetData")]
        public async Task<ActionResult<Timesheet>> GetTimesheetByProject([FromQuery] DateTime weekStart, [FromQuery] string projCode)
        {
            //DateOnly startDate = 
            // DateOnly endDate =;
            // int empID = 3;

            var startDate = new SqlParameter("@startDate", DateOnly.FromDateTime(weekStart));
            var endDate = new SqlParameter("@endDate", DateOnly.FromDateTime(weekStart).AddDays(7));

            var empID = new SqlParameter("@employeeID", 3);
            var projectCode = new SqlParameter("@projCode", projCode);


            var filteredData = _context.timeSheetDetailedDTO.FromSqlRaw("EXEC get_DetailedData @startDate,@endDate,@employeeID,@projCode", startDate, endDate, empID, projectCode).ToList();



            if (!filteredData.Any())
            {
                return NotFound($"No timesheet data found for week starting {weekStart}.");
            }

            return Ok(filteredData);
        }


        // POST: api/Timesheet
        [HttpPost("save-record")]
        public async Task<ActionResult<Timesheet>> PostEmployee([FromBody] Timesheet timesheet)
        {
            if (timesheet == null)
            {
                return BadRequest("Timesheet data is required.");
            }

            _context.Timesheets.Add(timesheet);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Timesheet submitted successfully", data = timesheet });
            
        }

        // PUT: api/Timesheet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesheet(int id, Timesheet Timesheet)
        {
            if (id != Timesheet.TimesheetId)
            {
                return BadRequest();
            }
            _context.Entry(Timesheet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Timesheet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimesheet(int id)
        {
            var Timesheet = await _context.Timesheets.FindAsync(id);
            if (Timesheet == null)
            {
                return NotFound();
            }
            _context.Timesheets.Remove(Timesheet);
            await _context.SaveChangesAsync();
           return Ok(new { Message = "Timesheet deleted successfully." });
        }
    }
}
