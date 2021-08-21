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
    public class DoantotnghiepsController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public DoantotnghiepsController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Doantotnghieps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doantotnghiep>>> GetDoantotnghieps()
        {
            return await _context.Doantotnghieps.ToListAsync();
        }

        // GET: api/Doantotnghieps/5
        [HttpGet("{maDoAnTN}")]
        public async Task<ActionResult<Doantotnghiep>> GetDoantotnghiep(int maDoAnTN)
        {
            var doantotnghiep = await _context.Doantotnghieps.FindAsync(maDoAnTN);

            if (doantotnghiep == null)
            {
                return NotFound();
            }

            return doantotnghiep;
        }

        // PUT: api/Doantotnghieps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maDoAnTN}")]
        public async Task<IActionResult> PutDoantotnghiep(int maDoAnTN, Doantotnghiep doantotnghiep)
        {
            if (maDoAnTN != doantotnghiep.Ma)
            {
                return BadRequest();
            }

            _context.Entry(doantotnghiep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoantotnghiepExists(maDoAnTN))
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

        // POST: api/Doantotnghieps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doantotnghiep>> PostDoantotnghiep(Doantotnghiep doantotnghiep)
        {
            _context.Doantotnghieps.Add(doantotnghiep);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoantotnghiepExists(doantotnghiep.Ma))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDoantotnghiep", new { id = doantotnghiep.Ma }, doantotnghiep);
        }

        // DELETE: api/Doantotnghieps/5
        [HttpDelete("{maDoAnTN}")]
        public async Task<IActionResult> DeleteDoantotnghiep(int maDoAnTN)
        {
            var doantotnghiep = await _context.Doantotnghieps.FindAsync(maDoAnTN);
            if (doantotnghiep == null)
            {
                return NotFound();
            }

            _context.Doantotnghieps.Remove(doantotnghiep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoantotnghiepExists(int maDoAnTN)
        {
            return _context.Doantotnghieps.Any(e => e.Ma == maDoAnTN);
        }
    }
}
