using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crop_Deal1.Models
{
    public class Crop_detail
    {
        public Crop_detail()
        {
            
        }

        [Key]
        [Required] 
        public int Crop_detailid { get; set;}
/*        [Required]
        public string? Crop_id { get; set;}
        [Required]
        public string? User_id { get; set;}*/
        [Required]
        public string? Crop_name { get; set;}
        [Required]
        public string? CropDetail_description { get; set;}
        [Required]  
        public string Crop_type { get; set;}
        [Required]  
        public int Quantity { get; set;}
        [Required]  
        public double Price { get; set;}
        [Required]
        public string? Location { get; set;}
        /*  [JsonIgnore]*/
        public virtual Crop Crop { get; set; }


    }
}
