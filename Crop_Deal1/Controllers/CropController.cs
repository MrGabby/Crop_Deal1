using Crop_Deal1.Dtos;
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Deal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {

        private readonly ICrop repo;
        public CropController(ICrop repo)
        {
            this.repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crop>>> GetCrops()
        {

            var crop = await repo.GetCrops();
            if (crop == null)
            {
                return NotFound();
            }
            var croplist = new List<Crop>();
            foreach (var c in crop)
            {
                croplist.Add(new Crop()
                { 

                 Cropid = c.Cropid,
                 Crop_name = c.Crop_name,
                 Crop_image = c.Crop_image,
                
                });

            }
            return Ok(croplist);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Crop>> GetCrop(int id)
        {
            var crop = await repo.GetCrop(id);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCrop(int id, Cropdto c)
        {
            var crop = await repo.UpdateCrop(id, c);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }

        [HttpPost]
        public async Task<ActionResult<Crop>> CreateCrop(Cropdto crop_detail)
        {
            var crop = await repo.CreateCrop(crop_detail);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }

        // DELETE: api/Crop_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop(int id)
        {
            var crop = await repo.DeleteCrop(id);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
