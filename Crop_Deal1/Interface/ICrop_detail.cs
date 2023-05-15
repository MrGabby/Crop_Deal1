using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface ICrop_detail
    {
        Task<Crop_detail> CreateCrop(Crop_detail user);
        Task<IEnumerable<Crop_detail>> GetCrop_details();
        Task<Crop_detail> GetCrop_detail(int id);
        Task<Crop_detail> UpdateCrop_detail(int id, Crop_detail user);
        Task<Crop_detail> DeleteCrop_detail(int id);

    }
}
