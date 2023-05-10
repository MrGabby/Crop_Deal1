using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface IBank_detail
    {
        Task<Bank_detail> CreateBank_acc(Bank_detail user);
        Task<List<Bank_detail>> GetBank_details();
        Task<Bank_detail> GetBank_detail(int id);
        Task<Bank_detail> UpdateBank_detail(int id, Bank_detail user);
        Task<Bank_detail> DeleteBank_acc(int id);
    }
}
