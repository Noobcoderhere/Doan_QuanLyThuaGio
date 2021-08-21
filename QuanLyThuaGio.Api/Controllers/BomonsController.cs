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
    public class BomonsController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public BomonsController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Bomons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bomon>>> GetListBomon()
        {
            return await _context.Bomons.ToListAsync();
        }

        // GET: api/Bomons/5
        [HttpGet("{maBoMon}")]
        public async Task<ActionResult<Bomon>> GetBomonDetail(string maBoMon)
        {
            var bomon = await _context.Bomons.FindAsync(maBoMon);

            if (bomon == null)
            {
                return NotFound();
            }

            return bomon;
        }

        // PUT: api/Bomons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{maBoMon}")]
        public async Task<IActionResult> PutBomon(string maBoMon, Bomon boMon)
        {   
            if (maBoMon != boMon.Mabomon)
            {
                return BadRequest();
            }

            _context.Entry(boMon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BomonExists(maBoMon))
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

        // POST: api/Bomons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bomon>> PostBomon(Bomon bomon)
        {
            _context.Bomons.Add(bomon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BomonExists(bomon.Mabomon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBomon", new { id = bomon.Mabomon }, bomon);
        }

        // DELETE: api/Bomons/5
        [HttpDelete("{maBoMon}")]
        public async Task<IActionResult> DeleteBomon(string maBoMon)
        {
            var bomon = await _context.Bomons.FindAsync(maBoMon);
            if (bomon == null)
            {
                return NotFound();
            }

            _context.Bomons.Remove(bomon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BomonExists(string maBoMon)
        {
            return _context.Bomons.Any(e => e.Mabomon == maBoMon);
        }
    }
}
