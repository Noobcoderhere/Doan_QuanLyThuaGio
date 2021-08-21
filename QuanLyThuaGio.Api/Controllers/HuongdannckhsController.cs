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
    public class HuongdannckhsController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public HuongdannckhsController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Huongdannckhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Huongdannckh>>> GetHuongdannckhs()
        {
            return await _context.Huongdannckhs.ToListAsync();
        }

        // GET: api/Huongdannckhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Huongdannckh>> GetHuongdannckh(string id)
        {
            var huongdannckh = await _context.Huongdannckhs.FindAsync(id);

            if (huongdannckh == null)
            {
                return NotFound();
            }

            return huongdannckh;
        }

        // PUT: api/Huongdannckhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuongdannckh(string id, Huongdannckh huongdannckh)
        {
            if (id != huongdannckh.Manckh)
            {
                return BadRequest();
            }

            _context.Entry(huongdannckh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HuongdannckhExists(id))
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

        // POST: api/Huongdannckhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Huongdannckh>> PostHuongdannckh(Huongdannckh huongdannckh)
        {
            _context.Huongdannckhs.Add(huongdannckh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HuongdannckhExists(huongdannckh.Manckh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHuongdannckh", new { id = huongdannckh.Manckh }, huongdannckh);
        }

        // DELETE: api/Huongdannckhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuongdannckh(string id)
        {
            var huongdannckh = await _context.Huongdannckhs.FindAsync(id);
            if (huongdannckh == null)
            {
                return NotFound();
            }

            _context.Huongdannckhs.Remove(huongdannckh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HuongdannckhExists(string id)
        {
            return _context.Huongdannckhs.Any(e => e.Manckh == id);
        }
    }
}
