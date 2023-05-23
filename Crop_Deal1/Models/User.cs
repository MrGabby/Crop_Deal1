using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Crop_Deal1.Models
{
    public class User
    {
        public User()
        {
            
        }
        [Key]
        public int Userid { get; set; }

        //-----------------------------------------------------------------
        [Required(ErrorMessage = "Please enter your name"), MinLength(3), MaxLength(50)]
        public string? Name { get; set; }

        //----------------------------------------------------------------- 
        [Required(ErrorMessage = "Please enter contact number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string? Contact { get; set; }

        public string? Roles { get; set; } = string.Empty;

        //-----------------------------------------------------------------

        [Required(ErrorMessage = "Please enter your email id")]
        [DataType(DataType.EmailAddress)]
        public string? Email_id { get; set; }

        //[Required]

        //public int Password { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }


        //-------------------------------------------------------------

        [Required(ErrorMessage = "Please enter your Address")]
        public string? Address { get; set; }


        //-------------------------------------------------------------

        public bool Is_subscribe { get; set; } = false;

        public bool Is_Active { get; set; } = false;
        [JsonIgnore]
        public List<Crop> Crops{ get; set; }
        [JsonIgnore]
        public List<Invoice> Invoices{ get; set; }
        [JsonIgnore]
        public IEnumerable<Bank_detail> Bank_details { get; set; }    

        //-----------------------------------------------------------------
        /*        public Crop Crop { get; set; }

                public int Crop_id { get; set; }*/
        /*   public Invoice Invoice { get; set; }*/
        /*       public int Invoice_id { get; set;}*/

        /*  public Bank_detail Bank_detail { get; set; } */
        /*
                [JsonIgnore]
                public List<Invoice> Invoices { get; set; }
                [JsonIgnore]
                public List<Bank_detail> Bank_details { get; set; }
                [JsonIgnore]
        */
        /*   public int bankid { get; set; }*/
     /*   [JsonIgnore]*/
    /*    public virtual Bank_detail bank_Detail { get; set; }*/



    }
}

