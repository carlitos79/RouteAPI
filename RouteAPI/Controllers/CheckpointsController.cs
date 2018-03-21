using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAPI.Models;

namespace RouteAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Checkpoints")]
    public class CheckpointsController : Controller
    {
        private readonly RouteAPIContext _context;

        public CheckpointsController(RouteAPIContext context)
        {
            _context = context;
        }

        // GET: api/Checkpoints
        [HttpGet]
        public IEnumerable<Checkpoint> GetCheckpoint()
        {
            return _context.Checkpoint;
        }

        // GET: api/Checkpoints/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCheckpoint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkpoint = await _context.Checkpoint.SingleOrDefaultAsync(m => m.CheckpointID == id);

            if (checkpoint == null)
            {
                return NotFound();
            }

            return Ok(checkpoint);
        }

        // PUT: api/Checkpoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckpoint([FromRoute] int id, [FromBody] Checkpoint checkpoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkpoint.CheckpointID)
            {
                return BadRequest();
            }

            _context.Entry(checkpoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckpointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Checkpoints
        [HttpPost]
        public async Task<IActionResult> PostCheckpoint([FromBody] Checkpoint checkpoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Checkpoint.Add(checkpoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckpoint", new { id = checkpoint.CheckpointID }, checkpoint);
        }

        // DELETE: api/Checkpoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckpoint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkpoint = await _context.Checkpoint.SingleOrDefaultAsync(m => m.CheckpointID == id);
            if (checkpoint == null)
            {
                return NotFound();
            }

            _context.Checkpoint.Remove(checkpoint);
            await _context.SaveChangesAsync();

            return Ok(checkpoint);
        }

        private bool CheckpointExists(int id)
        {
            return _context.Checkpoint.Any(e => e.CheckpointID == id);
        }
    }
}