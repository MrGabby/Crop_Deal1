using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface ICrop
    {
        Task<Crop> CreateCrop(Crop crop);
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop> GetCrop(int id);
        Task<Crop> UpdateCrop(int id, Crop crop);
        Task<Crop> DeleteCrop(int id);


    }
}
