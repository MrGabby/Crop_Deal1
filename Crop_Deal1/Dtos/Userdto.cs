using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crop_Deal1.Dtos
{
    public class Userdto
    {

   
        public string? Name { get; set; }

      
        public string Password { get; set; }
        //----------------------------------------------------------------- 
     
        public string? Contact { get; set; }


        //-----------------------------------------------------------------
     
        public string? Email_id { get; set; }

        //-------------------------------------------------------------
        public string? Address { get; set; }

        public string? Roles { get; set; } = string.Empty;

        public bool Is_subscribe { get; set; } = false;

    }
}
