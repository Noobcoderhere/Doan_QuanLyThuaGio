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
    public class HedaotaosController : ControllerBase
    {
        private readonly QUANLYTHUAGIOContext _context;

        public HedaotaosController(QUANLYTHUAGIOContext context)
        {
            _context = context;
        }

        // GET: api/Hedaotaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hedaotao>>> GetHedaotaos()
        {
            return await _context.Hedaotaos.ToListAsync();
        }

        // GET: api/Hedaotaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hedaotao>> GetHedaotao(string id)
        {
            var hedaotao = await _context.Hedaotaos.FindAsync(id);

            if (hedaotao == null)
            {
                return NotFound();
            }

            return hedaotao;
        }

        // PUT: api/Hedaotaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHedaotao(string id, Hedaotao hedaotao)
        {
            if (id != hedaotao.Mahedt)
            {
                return BadRequest();
            }

            _context.Entry(hedaotao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HedaotaoExists(id))
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

        // POST: api/Hedaotaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hedaotao>> PostHedaotao(Hedaotao hedaotao)
        {
            _context.Hedaotaos.Add(hedaotao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HedaotaoExists(hedaotao.Mahedt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHedaotao", new { id = hedaotao.Mahedt }, hedaotao);
        }

        // DELETE: api/Hedaotaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHedaotao(string id)
        {
            var hedaotao = await _context.Hedaotaos.FindAsync(id);
            if (hedaotao == null)
            {
                return NotFound();
            }

            _context.Hedaotaos.Remove(hedaotao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HedaotaoExists(string id)
        {
            return _context.Hedaotaos.Any(e => e.Mahedt == id);
        }
    }
}
