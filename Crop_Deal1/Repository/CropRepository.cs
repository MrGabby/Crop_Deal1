using Crop_Deal1.Interface;
using Crop_Deal1.Models;

namespace Crop_Deal1.Repository
{
    public class CropRepository : ICrop
    {
        Task<Crop> ICrop.CreateCrop(Crop crop)
        {
            throw new NotImplementedException();
        }

        Task<Crop> ICrop.DeleteCrop(int id)
        {
            throw new NotImplementedException();
        }

        Task<Crop> ICrop.GetCrop(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Crop>> ICrop.GetCrops()
        {
            throw new NotImplementedException();
        }

        Task<Crop> ICrop.UpdateCrop(int id, Crop crop)
        {
            throw new NotImplementedException();
        }
    }
}
