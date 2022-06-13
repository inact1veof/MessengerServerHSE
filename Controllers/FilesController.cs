using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly WebApiContext _context;

        public FilesController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Files
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<File>>> GetFileALL(int Limit)
        {
            return await _context.File.Take(Limit).ToListAsync();
        }

        // GET: api/Files/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<File>> GetFile(int id)
        {
            var file = await _context.File.FindAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            return file;
        }
        [HttpGet("{UserId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<File>>> GetFileUser(int UserId)
        {
            var files = await _context.File.Where(p => p.OwnerId == UserId).ToListAsync();
            return files;
        }

        // PUT: api/Files/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutFile(int id, File file)
        {
            if (id != file.Id)
            {
                return BadRequest();
            }

            _context.Entry(file).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileExists(id))
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

        // POST: api/Files
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<File>> PostFile(File file, string Content)
        {
            _context.File.Add(file);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFile", new { id = file.Id }, file);
        }

        // DELETE: api/Files/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var file = await _context.File.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            _context.File.Remove(file);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileExists(int id)
        {
            return _context.File.Any(e => e.Id == id);
        }
    }
}
