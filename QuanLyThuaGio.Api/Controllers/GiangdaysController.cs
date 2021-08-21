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
    public class GiangdaysController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public GiangdaysController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Giangdays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giangday>>> GetGiangdays()
        {
            return await _context.Giangdays.ToListAsync();
        }

        // GET: api/Giangdays/5
        [HttpGet("{maGV}")]
        public async Task<ActionResult<Giangday>> GetGiangday(string maGV)
        {
            var giangday = await _context.Giangdays.FindAsync(maGV);

            if (giangday == null)
            {
                return NotFound();
            }

            return giangday;
        }

        // PUT: api/Giangdays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maGV}")]
        public async Task<IActionResult> PutGiangday(string maGV, Giangday giangday)
        {
            if (maGV != giangday.Magv)
            {
                return BadRequest();
            }

            _context.Entry(giangday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiangdayExists(maGV))
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

        // POST: api/Giangdays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giangday>> PostGiangday(Giangday giangday)
        {
            _context.Giangdays.Add(giangday);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiangdayExists(giangday.Magv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiangday", new { id = giangday.Magv }, giangday);
        }

        // DELETE: api/Giangdays/5
        [HttpDelete("{maGV}")]
        public async Task<IActionResult> DeleteGiangday(string maGV)
        {
            var giangday = await _context.Giangdays.FindAsync(maGV);
            if (giangday == null)
            {
                return NotFound();
            }

            _context.Giangdays.Remove(giangday);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiangdayExists(string maGV)
        {
            return _context.Giangdays.Any(e => e.Magv == maGV);
        }
    }
}
