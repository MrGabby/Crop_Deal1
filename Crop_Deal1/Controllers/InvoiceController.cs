using Crop_Deal1.Dtos;
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Deal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoice repo;

        public InvoiceController(IInvoice repo)
        {
            this.repo = repo;
        }

        //  Repo DTO --------------------------------------------
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoicedto invoiced)
        {

            if (invoiced == null)
            {
                return BadRequest();
            }
            var invoice = new Invoice()
            {
                Quantity = invoiced.Quantity,
                Price = invoiced.Price,
                Payment_Mode = invoiced.Payment_Mode,
                Status = invoiced.Status
            };

            invoice = await repo.CreateInvoice(invoice);
            return Ok(invoice);
        }

        [HttpGet]
        public async Task<ActionResult<Invoice>> GetInvoices()
        {
            var invoices = await repo.GetInvoices();
            if (invoices == null)
            {
                return BadRequest();
            }

            var invoicelist = new List<Invoice>();

            foreach (var i in invoices)
            {
                invoicelist.Add(new Invoice()
                { 
                    Invoiceid=i.Invoiceid,
                    Quantity = i.Quantity,
                    Price = i.Price,
                  Payment_Mode = i.Payment_Mode, 
                    Status = i.Status,
                    Date_created = i.Date_created
                  
                });
            }

            return Ok(invoicelist);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await repo.GetInvoice(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {

            var invoice = await repo.DeleteInvoice(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
