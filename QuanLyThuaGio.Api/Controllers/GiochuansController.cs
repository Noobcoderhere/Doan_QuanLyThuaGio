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
    public class GiochuansController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public GiochuansController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Giochuans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giochuan>>> GetGiochuans()
        {
            return await _context.Giochuans.ToListAsync();
        }

        // GET: api/Giochuans/5
        [HttpGet("{maChucDanh}")]
        public async Task<ActionResult<Giochuan>> GetGiochuan(string maChucDanh)
        {
            var giochuan = await _context.Giochuans.FindAsync(maChucDanh);

            if (giochuan == null)
            {
                return NotFound();
            }

            return giochuan;
        }

        // PUT: api/Giochuans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maChucDanh}")]
        public async Task<IActionResult> PutGiochuan(string maChucDanh, Giochuan giochuan)
        {
            if (maChucDanh != giochuan.Machucdanh)
            {
                return BadRequest();
            }

            _context.Entry(giochuan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiochuanExists(maChucDanh))
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

        // POST: api/Giochuans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giochuan>> PostGiochuan(Giochuan giochuan)
        {
            _context.Giochuans.Add(giochuan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiochuanExists(giochuan.Machucdanh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiochuan", new { id = giochuan.Machucdanh }, giochuan);
        }

        // DELETE: api/Giochuans/5
        [HttpDelete("{maChucDanh}")]
        public async Task<IActionResult> DeleteGiochuan(string maChucDanh)
        {
            var giochuan = await _context.Giochuans.FindAsync(maChucDanh);
            if (giochuan == null)
            {
                return NotFound();
            }

            _context.Giochuans.Remove(giochuan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiochuanExists(string maChucDanh)
        {
            return _context.Giochuans.Any(e => e.Machucdanh == maChucDanh);
        }
    }
}
