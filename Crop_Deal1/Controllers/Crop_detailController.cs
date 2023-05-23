using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crop_Deal1.Data;
using Crop_Deal1.Models;
using Crop_Deal1.Interface;
using Crop_Deal1.Dtos;

namespace Crop_Deal1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Crop_detailController : ControllerBase
    {
        private readonly ICrop_detail repo;
        public Crop_detailController(ICrop_detail repo)
        {
            this.repo = repo;
        }


         [HttpGet]
        public async Task<ActionResult<IEnumerable<Crop_detail>>> GetCrop_details()
        {

            var crop = await repo.GetCrop_details();
            if (crop == null)
            {
                return NotFound();
            }
            var croplist = new List<Crop_detail>();
            foreach (var c in crop)
            {
                croplist.Add(new Crop_detail()
                {
                    Crop_detailid = c.Crop_detailid,
                    Crop_name = c.Crop_name,
                    Crop_type = c.Crop_type,
                    CropDetail_description = c.CropDetail_description,
                    Quantity = c.Quantity,
                    Price = c.Price,
                    Location = c.Location


                });

            }
            return Ok(croplist);    

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Crop_detail>> GetCrop_detail(int id)
        { 
            var crop = await repo.GetCrop_detail(id);
            if(crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
      }
      [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCrop_detail(int id, Crop_detail crop_detail)
        {
           var crop = await repo.UpdateCrop_detail(id, crop_detail);
            if(crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }

       [HttpPost]
        public async Task<ActionResult<Crop_detail>> CreateCrop(Crop_detaildto crop_detail)
        {

            var crop = new Crop_detail()
            {
                Crop_name = crop_detail.Crop_name,
                CropDetail_description= crop_detail.CropDetail_description,
                Crop_type = crop_detail.Crop_type,
                Quantity= crop_detail.Quantity,
                Price = crop_detail.Price,
                Location = crop_detail.Location 
            };
            var c  = await repo.CreateCrop(crop);
            if (c == null)
            {
                return NotFound();
            }
            return Ok(c);
       }

        // DELETE: api/Crop_detail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop_detail(int id)
        {
          var crop = await repo.DeleteCrop_detail(id);
            if(crop == null)
            {
                return NotFound();
            }
            return Ok();
        }

      
    }
}
