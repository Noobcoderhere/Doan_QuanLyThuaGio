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
    public class GiaoviensController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public GiaoviensController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Giaoviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giaovien>>> GetGiaoviens()
        {
            return await _context.Giaoviens.ToListAsync();
        }

        // GET: api/Giaoviens/5
        [HttpGet("{maGV}")]
        public async Task<ActionResult<Giaovien>> GetGiaovien(string maGV)
        {
            var giaovien = await _context.Giaoviens.FindAsync(maGV);

            if (giaovien == null)
            {
                return NotFound();
            }

            return giaovien;
        }

        // PUT: api/Giaoviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maGV}")]
        public async Task<IActionResult> PutGiaovien(string maGV, Giaovien giaovien)
        {
            if (maGV != giaovien.Magv)
            {
                return BadRequest();
            }

            _context.Entry(giaovien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaovienExists(maGV))
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

        // POST: api/Giaoviens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giaovien>> PostGiaovien(Giaovien giaovien)
        {
            _context.Giaoviens.Add(giaovien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiaovienExists(giaovien.Magv))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiaovien", new { maGV = giaovien.Magv }, giaovien);
        }

        // DELETE: api/Giaoviens/5
        [HttpDelete("{maGV}")]
        public async Task<IActionResult> DeleteGiaovien(string maGV)
        {
            var giaovien = await _context.Giaoviens.FindAsync(maGV);
            if (giaovien == null)
            {
                return NotFound();
            }

            _context.Giaoviens.Remove(giaovien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaovienExists(string maGV)
        {
            return _context.Giaoviens.Any(e => e.Magv == maGV);
        }
    }
}
