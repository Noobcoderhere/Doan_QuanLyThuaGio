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
    public class ChucvusController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public ChucvusController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Chucvus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chucvu>>> GetChucvus()
        {
            return await _context.Chucvus.ToListAsync();
        }

        // GET: api/Chucvus/5
        [HttpGet("{maChucVu}")]
        public async Task<ActionResult<Chucvu>> GetChucvu(string maChucVu)
        {
            var chucvu = await _context.Chucvus.FindAsync(maChucVu);

            if (chucvu == null)
            {
                return NotFound();
            }

            return chucvu;
        }

        // PUT: api/Chucvus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maChucVu}")]
        public async Task<IActionResult> PutChucvu(string maChucVu, Chucvu chucvu)
        {
            if (maChucVu != chucvu.Machucvu)
            {
                return BadRequest();
            }

            _context.Entry(chucvu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucvuExists(maChucVu))
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

        // POST: api/Chucvus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chucvu>> PostChucvu(Chucvu chucvu)
        {
            _context.Chucvus.Add(chucvu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChucvuExists(chucvu.Machucvu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChucvu", new { id = chucvu.Machucvu }, chucvu);
        }

        // DELETE: api/Chucvus/5
        [HttpDelete("{maChucVu}")]
        public async Task<IActionResult> DeleteChucvu(string maChucVu)
        {
            var chucvu = await _context.Chucvus.FindAsync(maChucVu);
            if (chucvu == null)
            {
                return NotFound();
            }

            _context.Chucvus.Remove(chucvu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChucvuExists(string maChucVu)
        {
            return _context.Chucvus.Any(e => e.Machucvu == maChucVu);
        }
    }
}
