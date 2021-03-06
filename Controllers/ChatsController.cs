using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Data;
using WebApi.Controllers;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public ChatsController(WebApiContext context)
        {
            _context = context;
        }
        // GET: api/Chats
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChatA(int Limit)
        {
            return await _context.Chat.Take(Limit).ToListAsync();
        }
        [HttpGet("{UserId}, {flag}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Chat>>> GetUserChats(int UserId, int flag)
        {
            var chats = await _context.Chat.ToListAsync();
            List<int> tempArr = new List<int>();
            List<Chat> returnChats = new List<Chat>();
            foreach (var chat in chats)
            {
                tempArr = chat.Members.ToList();
                if (tempArr.Contains(UserId))
                {
                    returnChats.Add(chat);
                }
                tempArr = new List<int>();
            }
            if (returnChats.Count == 0)
            {
                return NotFound();
            }
            //var chats = await _context.Chat.Where(p => p.Members.Contains(UserId)).ToListAsync();
            return returnChats;
        }
        // GET: api/Chats/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
            var chat = await _context.Chat.FindAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }
        // PUT: api/Chats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutChat(int id, Chat chat)
        {
            if (id != chat.Id)
            {
                return BadRequest();
            }

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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
        // POST: api/Chats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Chat>> PostChat(Chat chat)
        {
            _context.Chat.Add(chat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = chat.Id }, chat);
        }
        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteChat(int id)
        {
            var chat = await _context.Chat.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Chat.Remove(chat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatExists(int id)
        {
            return _context.Chat.Any(e => e.Id == id);
        }
    }
}
