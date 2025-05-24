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
    public class DisciplineCodesController : ControllerBase
    {
        private readonly UccdataContext _context;

        public DisciplineCodesController(UccdataContext context)
        {
            _context = context;
        }

        // GET: api/DisciplineCode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplineCode>>> GetDisciplineCode()
        {
            return await _context.DisciplineCodes.ToListAsync();
        }

        // GET: api/DisciplineCode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplineCode>> GetDisciplineCode(int id)
        {
            var DisciplineCode = await _context.DisciplineCodes.FindAsync(id);
            if (DisciplineCode == null)
            {
                return NotFound();
            }
            return DisciplineCode;
        }

        // POST: api/DisciplineCode
        [HttpPost]
        public async Task<ActionResult<DisciplineCode>> PostEmployee(DisciplineCode DisciplineCode)
        {
            _context.DisciplineCodes.Add(DisciplineCode);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDisciplineCode", new { id = DisciplineCode.DisciplineCodeId }, DisciplineCode);
        }

        // PUT: api/DisciplineCode/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplineCode(int id, DisciplineCode DisciplineCode)
        {
            if (id != DisciplineCode.DisciplineCodeId)
            {
                return BadRequest();
            }
            _context.Entry(DisciplineCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/DisciplineCode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplineCode(int id)
        {
            var DisciplineCode = await _context.DisciplineCodes.FindAsync(id);
            if (DisciplineCode == null)
            {
                return NotFound();
            }
            _context.DisciplineCodes.Remove(DisciplineCode);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
