using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface ICrop_detail
    {
        Task<Crop_detail> CreateCrop_acc(Crop_detail user);
        Task<List<Crop_detail>> GetCrop_details();
        Task<Crop_detail> GetCrop_detail(int id);
        Task<Crop_detail> UpdateCrop_detail(int id, Crop_detail user);
        Task<Crop_detail> DeleteCrop_acc(int id);

    }
}
