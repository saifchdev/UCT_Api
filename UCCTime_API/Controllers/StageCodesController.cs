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
    public class StagesController : ControllerBase
    {
        private readonly UccdataContext _context;

        public StagesController(UccdataContext context)
        {
            _context = context;
        }

        // GET: api/Stages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stages>>> GetStages()
        {
            return await _context.Stages.ToListAsync();
        }

        // GET: api/Stages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stages>> GetStages(int id)
        {
            var Stages = await _context.Stages.FindAsync(id);
            if (Stages == null)
            {
                return NotFound();
            }
            return Stages;
        }

        // POST: api/Stages
        [HttpPost]
        public async Task<ActionResult<Stages>> PostEmployee(Stages Stages)
        {
            _context.Stages.Add(Stages);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetStages", new { id = Stages.StageId }, Stages);
        }

        // PUT: api/Stages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStages(int id, Stages Stages)
        {
            if (id != Stages.StageId)
            {
                return BadRequest();
            }
            _context.Entry(Stages).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Stages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStages(int id)
        {
            var Stages = await _context.Stages.FindAsync(id);
            if (Stages == null)
            {
                return NotFound();
            }
            _context.Stages.Remove(Stages);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
