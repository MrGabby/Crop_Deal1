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
       /*     var invoice = new Invoice()
            {
                Name = invoiced.Name,
                Amount = invoiced.Amount,
                PaymentStatus = invoiced.PaymentStatus,
                Date = invoiced.Date
            };
*/
         /*   invoice = await repo.CreateInvoice(invoice);*/
            return Ok(invoiced);
        }

        [HttpGet]
        public async Task<ActionResult<Invoice>> GetInvoices()
        {
            var invoices = await repo.GetInvoices();
            if (invoices == null)
            {
                return BadRequest();
            }

        /*    var invoicelist = new List<Invoicedto>();

            foreach (var i in invoices)
            {
                invoicelist.Add(new Invoicedto()
                {
                    Name = i.Name,
                    Amount = i.Amount,
                    PaymentStatus = i.PaymentStatus,
                    Date = i.Date
                });
            }
*/
            return Ok(invoices);
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


        [HttpPut("{id}")]
        public async Task<ActionResult<Invoice>> UpdateInvoice(int id, Invoice invoice)
        {
            if (invoice == null)
            {
                return NotFound();
            }

            var database_invoice = repo.UpdateInvoice(id, invoice);
            if (database_invoice == null)
            {
                NotFound();
            }
            return Ok();
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
