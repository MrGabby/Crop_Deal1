namespace Crop_Deal1.Dtos
{
    public class Invoicedto
    { 

        
        public int Quantity { get; set; }
        public double Price { get; set; }

        public string Payment_Mode { get; set; } = string.Empty;


        public string Status { get; set; } = "Pending";

    
    }
}
