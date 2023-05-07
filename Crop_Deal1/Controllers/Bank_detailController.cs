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
    public class Bank_detailController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public Bank_detailController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Bank_detail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank_detail>>> GetBank_details()
        {
          if (_context.Bank_details == null)
          {
              return NotFound();
          }
            return await _context.Bank_details.ToListAsync();
        }

        // GET: api/Bank_detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bank_detail>> GetBank_detail(int id)
        {
          if (_context.Bank_details == null)
          {
              return NotFound();
          }
            var bank_detail = await _context.Bank_details.FindAsync(id);

            if (bank_detail == null)
            {
                return NotFound();
            }

            return bank_detail;
        } 
        
        [HttpGet("{Userid}")]
        public async Task<ActionResult<Bank_detail>> GetUser(int Userid)
        {
          if (_context.Bank_details == null)
          {
              return NotFound();
          }
            var bank_detail = await _context.Bank_details.FindAsync(Userid);

            if (bank_detail == null)
            {
                return NotFound();
            }

            return bank_detail;
        }

        [HttpPost]
        public async Task<ActionResult<Bank_detail>> PostBank_detail(Bank_detail bank_detail)
        {
          if (_context.Bank_details == null)
          {
              return Problem("Invalid Details Entered");
          }
            _context.Bank_details.Add(bank_detail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank_detail", new { id = bank_detail.Bank_detailid }, bank_detail);
        }

 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank_detail(int id)
        {
            if (_context.Bank_details == null)
            {
                return NotFound();
            }
            var bank_detail = await _context.Bank_details.FindAsync(id);
            if (bank_detail == null)
            {
                return NotFound();
            }

            _context.Bank_details.Remove(bank_detail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

      
    }
}
