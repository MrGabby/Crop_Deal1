using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface IInvoice
    {
        Task<Invoice> CreateInvoice(Invoice invoice);
        Task<List<Invoice>> GetInvoices();
        Task<Invoice> GetInvoice(int id);
        Task<Invoice> UpdateInvoice(int id, Invoice invoice);
        Task<Invoice> DeleteInvoice(int id);

    }
}
