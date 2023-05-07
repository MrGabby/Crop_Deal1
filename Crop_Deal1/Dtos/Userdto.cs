using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crop_Deal1.Dtos
{
    public class Userdto
    {

        [Required(ErrorMessage = "Please enter your name"), MinLength(3), MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        public int Password { get; set; }
        //----------------------------------------------------------------- 
        [Required(ErrorMessage = "Please enter contact number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string? Contact { get; set; }


        //-----------------------------------------------------------------
        [Required(ErrorMessage = "Please enter your email id")]
        [DataType(DataType.EmailAddress)]

        public string? Email_id { get; set; }

        //-------------------------------------------------------------

        [Required(ErrorMessage = "Please enter your Address")]
        public string? Address { get; set; }

        public string? Roles { get; set; } = string.Empty;

        public bool Is_subscribe { get; set; } = false;

    }
}
