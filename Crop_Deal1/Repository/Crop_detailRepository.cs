using Crop_Deal1.Interface;
using Crop_Deal1.Models;

namespace Crop_Deal1.Repository
{
    public class Crop_detailRepository : ICrop_detail
    {
        Task<Crop_detail> ICrop_detail.CreateCrop_acc(Crop_detail user)
        {
            throw new NotImplementedException();
        }

        Task<Crop_detail> ICrop_detail.DeleteCrop_acc(int id)
        {
            throw new NotImplementedException();
        }

        Task<Crop_detail> ICrop_detail.GetCrop_detail(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Crop_detail>> ICrop_detail.GetCrop_details()
        {
            throw new NotImplementedException();
        }

        Task<Crop_detail> ICrop_detail.UpdateCrop_detail(int id, Crop_detail user)
        {
            throw new NotImplementedException();
        }
    }
}
