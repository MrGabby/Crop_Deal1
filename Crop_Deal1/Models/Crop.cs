using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Crop_Deal1.Models
{
    public class Crop
    { 
        public Crop() { }
        [Key]
        [Required]
        public int Cropid {get; set;}
        [Required]
        public string? Crop_name { get; set;}
        [Required]
        public string? Crop_image { get; set;}


        /*  [JsonIgnore]*/
        /*       [ForeignKey("Crop_Detail")]
        */
        public int Crop_detailid { get; set; }
        [JsonIgnore]
        public  Crop_detail Crop_Detail { get; set; }

        public int Userid { get; set; }
        [JsonIgnore]
        public User User { get; set; }

    }
}
