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
    public class HocnangcaosController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public HocnangcaosController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Hocnangcaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hocnangcao>>> GetHocnangcaos()
        {
            return await _context.Hocnangcaos.ToListAsync();
        }

        // GET: api/Hocnangcaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hocnangcao>> GetHocnangcao(int id)
        {
            var hocnangcao = await _context.Hocnangcaos.FindAsync(id);

            if (hocnangcao == null)
            {
                return NotFound();
            }

            return hocnangcao;
        }

        // PUT: api/Hocnangcaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocnangcao(int id, Hocnangcao hocnangcao)
        {
            if (id != hocnangcao.Mahocnangcao)
            {
                return BadRequest();
            }

            _context.Entry(hocnangcao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocnangcaoExists(id))
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

        // POST: api/Hocnangcaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hocnangcao>> PostHocnangcao(Hocnangcao hocnangcao)
        {
            _context.Hocnangcaos.Add(hocnangcao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HocnangcaoExists(hocnangcao.Mahocnangcao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHocnangcao", new { id = hocnangcao.Mahocnangcao }, hocnangcao);
        }

        // DELETE: api/Hocnangcaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocnangcao(int id)
        {
            var hocnangcao = await _context.Hocnangcaos.FindAsync(id);
            if (hocnangcao == null)
            {
                return NotFound();
            }

            _context.Hocnangcaos.Remove(hocnangcao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocnangcaoExists(int id)
        {
            return _context.Hocnangcaos.Any(e => e.Mahocnangcao == id);
        }
    }
}
