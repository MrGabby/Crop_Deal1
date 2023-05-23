using Crop_Deal1.Dtos;
using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface ICrop
    {
        Task<Crop> CreateCrop(Cropdto crop);
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop> GetCrop(int id);
        Task<Crop> UpdateCrop(int id, Cropdto crop);
        Task<Crop> DeleteCrop(int id);


    }
}
    