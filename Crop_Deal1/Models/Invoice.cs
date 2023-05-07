using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Crop_Deal1.Models
{
    public class Invoice
    {
        public Invoice()
        {
            
        }

        [Key]
        public int Invoiceid { get; set; }

/*        [Required]
        //-----------------------------------------------------------------
        public string User_id { get; set; } = string.Empty;*/
/*        [Required]

        public string CropDetails_id{ get; set; } = string.Empty;*/

        [Required]
        public int  Quantity { get; set; }

        [Required]
        public string Payment_Mode { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public DateTime  Date_created { get; set; }

        /*   [JsonIgnore]*/
        /*  public User user { get; set; }*/

        public int Userid { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public int Crop_detailid { get; set; }
        [JsonIgnore]
        public Crop_detail Crop_Detail { get; set; }

    }
}
