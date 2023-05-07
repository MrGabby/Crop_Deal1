using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crop_Deal1.Data;
using Crop_Deal1.Models;

namespace Crop_Deal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Crop_detailController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public Crop_detailController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Crop_detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crop_detail>>> GetCrop_details()
        {
          if (_context.Crop_details == null)
          {
              return NotFound();
          }
            return await _context.Crop_details.ToListAsync();
        }

        // GET: api/Crop_detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crop_detail>> GetCrop_detail(int id)
        {
          if (_context.Crop_details == null)
          {
              return NotFound();
          }
            var crop_detail = await _context.Crop_details.FindAsync(id);

            if (crop_detail == null)
            {
                return NotFound();
            }

            return crop_detail;
        }

        // PUT: api/Crop_detail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrop_detail(int id, Crop_detail crop_detail)
        {
            if (id != crop_detail.Crop_detailid)
            {
                return BadRequest();
            }

            _context.Entry(crop_detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Crop_detailExists(id))
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

        // POST: api/Crop_detail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Crop_detail>> PostCrop_detail(Crop_detail crop_detail)
        {
          if (_context.Crop_details == null)
          {
              return Problem("Entity set 'ApiDbContext.Crop_details'  is null.");
          }
            _context.Crop_details.Add(crop_detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrop_detail", new { id = crop_detail.Crop_detailid }, crop_detail);
        }

        // DELETE: api/Crop_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop_detail(int id)
        {
            if (_context.Crop_details == null)
            {
                return NotFound();
            }
            var crop_detail = await _context.Crop_details.FindAsync(id);
            if (crop_detail == null)
            {
                return NotFound();
            }

            _context.Crop_details.Remove(crop_detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Crop_detailExists(int id)
        {
            return (_context.Crop_details?.Any(e => e.Crop_detailid == id)).GetValueOrDefault();
        }
    }
}
