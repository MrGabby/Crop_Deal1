using Crop_Deal1.Interface;
using Crop_Deal1.Models;

namespace Crop_Deal1.Repository
{
    public class InvoiceRepository : IInvoice
    {
        Task<Invoice> IInvoice.CreateInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        Task<Invoice> IInvoice.DeleteInvoice(int id)
        {
            throw new NotImplementedException();
        }

        Task<Invoice> IInvoice.GetInvoice(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Invoice>> IInvoice.GetInvoices()
        {
            throw new NotImplementedException();
        }

        Task<Invoice> IInvoice.UpdateInvoice(int id, Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
