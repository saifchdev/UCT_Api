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
    public class ProjectController : ControllerBase
    {
        private readonly UccdataContext _context;

        public ProjectController(UccdataContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var Project = await _context.Projects.FindAsync(id);
            if (Project == null)
            {
                return NotFound();
            }
            return Project;
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project Project)
        {
            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProject", new { id = Project.ProjectId }, Project);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project Project)
        {
            if (id != Project.ProjectId)
            {
                return BadRequest();
            }
            _context.Entry(Project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var Project = await _context.Projects.FindAsync(id);
            if (Project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(Project);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
