using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyThuaGio.Api.Data;
using QuanLyThuaGio.Api.Entities;

namespace QuanLyThuaGio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QlphongmaysController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public QlphongmaysController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Qlphongmays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qlphongmay>>> GetQlphongmays()
        {
            return await _context.Qlphongmays.ToListAsync();
        }

        // GET: api/Qlphongmays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Qlphongmay>> GetQlphongmay(string id)
        {
            var qlphongmay = await _context.Qlphongmays.FindAsync(id);

            if (qlphongmay == null)
            {
                return NotFound();
            }

            return qlphongmay;
        }

        // PUT: api/Qlphongmays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQlphongmay(string id, Qlphongmay qlphongmay)
        {
            if (id != qlphongmay.Maql)
            {
                return BadRequest();
            }

            _context.Entry(qlphongmay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QlphongmayExists(id))
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

        // POST: api/Qlphongmays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Qlphongmay>> PostQlphongmay(Qlphongmay qlphongmay)
        {
            _context.Qlphongmays.Add(qlphongmay);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QlphongmayExists(qlphongmay.Maql))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQlphongmay", new { id = qlphongmay.Maql }, qlphongmay);
        }

        // DELETE: api/Qlphongmays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQlphongmay(string id)
        {
            var qlphongmay = await _context.Qlphongmays.FindAsync(id);
            if (qlphongmay == null)
            {
                return NotFound();
            }

            _context.Qlphongmays.Remove(qlphongmay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QlphongmayExists(string id)
        {
            return _context.Qlphongmays.Any(e => e.Maql == id);
        }
    }
}
