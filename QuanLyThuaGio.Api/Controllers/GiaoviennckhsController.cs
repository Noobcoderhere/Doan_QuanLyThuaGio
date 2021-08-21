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
    public class GiaoviennckhsController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public GiaoviennckhsController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Giaoviennckhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giaoviennckh>>> GetGiaoviennckhs()
        {
            return await _context.Giaoviennckhs.ToListAsync();
        }

        // GET: api/Giaoviennckhs/5
        [HttpGet("{maDeTai}")]
        public async Task<ActionResult<Giaoviennckh>> GetGiaoviennckh(string maDeTai)
        {
            var giaoVienNCKH = await _context.Giaoviennckhs.FindAsync(maDeTai);

            if (giaoVienNCKH == null)
            {
                return NotFound();
            }

            return giaoVienNCKH;
        }

        // PUT: api/Giaoviennckhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maDeTai}")]
        public async Task<IActionResult> PutGiaoviennckh(string maDeTai, Giaoviennckh giaoVienNCKH)
        {
            if (maDeTai != giaoVienNCKH.Madetai)
            {
                return BadRequest();
            }

            _context.Entry(giaoVienNCKH).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaoviennckhExists(maDeTai))
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

        // POST: api/Giaoviennckhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giaoviennckh>> PostGiaoviennckh(Giaoviennckh giaoVienNCKH)
        {
            _context.Giaoviennckhs.Add(giaoVienNCKH);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiaoviennckhExists(giaoVienNCKH.Madetai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiaoviennckh", new { id = giaoVienNCKH.Madetai }, giaoVienNCKH);
        }

        // DELETE: api/Giaoviennckhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiaoviennckh(string maDeTai)
        {
            var giaoVienNCKH = await _context.Giaoviennckhs.FindAsync(maDeTai);
            if (giaoVienNCKH == null)
            {
                return NotFound();
            }

            _context.Giaoviennckhs.Remove(giaoVienNCKH);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaoviennckhExists(string maDeTai)
        {
            return _context.Giaoviennckhs.Any(e => e.Madetai == maDeTai);
        }
    }
}
