using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonarsService;
using DonarsService.Data;

namespace DonarsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarsController : ControllerBase
    {
        private readonly DonarsServiceContext _context;

        public DonarsController(DonarsServiceContext context)
        {
            _context = context;
        }

        // GET: api/Donars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donar>>> GetDonar()
        {
            return await _context.Donar.ToListAsync();
        }

        // GET: api/Donars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donar>> GetDonar(int id)
        {
            var donar = await _context.Donar.FindAsync(id);

            if (donar == null)
            {
                return NotFound();
            }

            return donar;
        }

        // PUT: api/Donars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonar(int id, Donar donar)
        {
            if (id != donar.DonorId)
            {
                return BadRequest();
            }

            _context.Entry(donar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonarExists(id))
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

        // POST: api/Donars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Donar>> PostDonar(Donar donar)
        {
            _context.Donar.Add(donar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonar", new { id = donar.DonorId }, donar);
        }

        // DELETE: api/Donars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Donar>> DeleteDonar(int id)
        {
            var donar = await _context.Donar.FindAsync(id);
            if (donar == null)
            {
                return NotFound();
            }

            _context.Donar.Remove(donar);
            await _context.SaveChangesAsync();

            return donar;
        }

        private bool DonarExists(int id)
        {
            return _context.Donar.Any(e => e.DonorId == id);
        }
    }
}
