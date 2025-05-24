using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using UCCTime_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UCCTime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCodesController : ControllerBase
    {
        private readonly UccdataContext _context;

        public TaskCodesController(UccdataContext context)
        {
            _context = context;
        }

        // GET: api/TaskCode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTaskCode()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/TaskCode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTaskCode(int id)
        {
            var TaskCode = await _context.Tasks.FindAsync(id);
            if (TaskCode == null)
            {
                return NotFound();
            }
            return TaskCode;
        }

        // POST: api/TaskCode
        [HttpPost]
        public async Task<ActionResult<Tasks>> PostEmployee(Tasks Tasks)
        {
            _context.Tasks.Add(Tasks);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTaskCode", new { id = Tasks.TaskId }, Tasks);
        }

        // PUT: api/TaskCode/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskCode(int id, Tasks TaskCode)
        {
            if (id != TaskCode.TaskId)
            {
                return BadRequest();
            }
            _context.Entry(TaskCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/TaskCode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskCode(int id)
        {
            var TaskCode = await _context.Tasks.FindAsync(id);
            if (TaskCode == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(TaskCode);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
