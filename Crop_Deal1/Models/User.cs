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
    
        public string? Name { get; set; }

        //----------------------------------------------------------------- 
        [Required(ErrorMessage = "Please enter contact number")]
        [DataType(DataType.PhoneNumber)]
     
        public string? Contact { get; set; }

        public string? Roles { get; set; } = string.Empty;

        //-----------------------------------------------------------------

        [DataType(DataType.EmailAddress)]

        public string? Email_id { get; set; }

        [Required]
        public int Password { get; set; }


        //-------------------------------------------------------------

        [Required(ErrorMessage = "Please enter your Address")]
        public string? Address { get; set; }


        //-------------------------------------------------------------

        public bool Is_subscribe { get; set; } = false;

        public bool Is_Active { get; set; } = false;

        public List<Crop> Crops{ get; set; }
        public List<Invoice> Invoices{ get; set; }

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

