using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Crop_Deal1.Models
{
    public class Bank_detail
    {
        [Key]
    /*    [ForeignKey("User")]*/
        public int Bank_detailid { get; set; }

        [Required(ErrorMessage = "Please enter your Bank Name")]
        public string? Bank_name { get; set; }

        //-------------------------------------------------------------

        [Required(ErrorMessage = "Please enter your Bank Account number")]
        public string? Account_no { get; set; }

        //-------------------------------------------------------------

        [Required(ErrorMessage = "Please enter  IFSC code")]
        public string? IFSC { get; set; }
        public int Userid { get; set; }
        [JsonIgnore]
        public  User? User { get; set; }
    }
}
