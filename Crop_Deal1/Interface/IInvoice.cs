using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface IInvoice
    {
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<Invoice> GetInvoice(int id);
        Task<Invoice> DeleteInvoice(int id);

    }
}
