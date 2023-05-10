using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crop_Deal1.Data;
using Crop_Deal1.Models;
using Crop_Deal1.Interface;
using Crop_Deal1.Dtos;

namespace Crop_Deal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bank_detailController : ControllerBase
    {

        private readonly IBank_detail repo;
        public Bank_detailController(IBank_detail repo)
        {
            this.repo = repo;
        }


        [HttpPost]
        public async Task<ActionResult<Bank_detail>> PostBank_detail(Bank_detail bank_detail)
        {

            var details = await repo.CreateBank_acc(bank_detail);
            if (details == null)
            {
                return NotFound();
            }
           
         return Ok();
        }


        // GET: api/Bank_detail
        [HttpGet]
        public async Task<ActionResult<List<Bank_detail>>> GetBank_details()
        {
            var details= await repo.GetBank_details();
          if (details == null)
          {
              return NotFound();
          }
            var list = new List<Bank_detaildto>();

            foreach (var i in details)
            {
                list.Add(new Bank_detaildto()
                {
                    Bank_name = i.Bank_name,
                    Account_no= i.Account_no,
                     IFSC = i.IFSC
                });
            }

            return Ok(list);
        }

        // GET: api/Bank_detail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bank_detail>> GetBank_detail(int id)
        {

            var detail = await repo.GetBank_detail(id);
            if (detail == null)
            {
                return NotFound();
            }

            return Ok(detail);
        }

        /*        [HttpGet("{Userid}")]
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
        */

        [HttpPut("{id}")]
        public async Task<ActionResult<Bank_detail>> UpdateBank_detail(int id, Bank_detail user)
        {

            var detail = await repo.UpdateBank_detail(id,user);
            if (detail == null)
            {
                return NotFound();
            }

            return Ok(detail);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank_acc(int id)
        {
            var details = await repo.DeleteBank_acc(id);
            if (details == null)
            {
                return NotFound();
            }
            return Ok();
        }

      
    }
}
