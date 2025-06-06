using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTaskManager.Data;
using SmartTaskManager.Models;

namespace SmartTaskManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WorkspaceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkspaceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/workspace
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workspaces = await _context.Workspaces.Include(w => w.Tasks).ToListAsync();
            return Ok(workspaces);
        }

        // GET: api/workspace/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workspace = await _context.Workspaces
                .Include(w => w.Tasks)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workspace == null)
                return NotFound();

            return Ok(workspace);
        }

        // POST: api/workspace
        [HttpPost]
        public async Task<IActionResult> Create(Workspace workspace)
        {
            _context.Workspaces.Add(workspace);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = workspace.Id }, workspace);
        }

        // PUT: api/workspace/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Workspace updated)
        {
            var workspace = await _context.Workspaces.FindAsync(id);
            if (workspace == null)
                return NotFound();

            workspace.Name = updated.Name;
            await _context.SaveChangesAsync();

            return Ok(workspace);
        }

        // DELETE: api/workspace/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var workspace = await _context.Workspaces.FindAsync(id);
            if (workspace == null)
                return NotFound();

            _context.Workspaces.Remove(workspace);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
