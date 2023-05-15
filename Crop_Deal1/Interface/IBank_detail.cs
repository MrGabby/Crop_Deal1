using Crop_Deal1.Dtos;
using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface IBank_detail
    {
        Task<Bank_detail> CreateBank_acc(Bank_detaildto user);
        Task<IEnumerable<Bank_detail>> GetBank_details();
        Task<IEnumerable<Bank_detail>> GetUserwithBank_details();

        Task<Bank_detail> GetBank_detail(int id);
        Task<Bank_detail> UpdateBank_detail(int id, Bank_detail user);
        Task<Bank_detail> DeleteBank_acc(int id);
    }
}
