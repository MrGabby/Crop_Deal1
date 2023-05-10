namespace Crop_Deal1.Dtos
{
    public class Invoicedto
    {
        public int Invoiceid { get; set; }

        public int Quantity { get; set; }

        public string Payment_Mode { get; set; } = string.Empty;


        public string Status { get; set; } = string.Empty;

        public DateTime Date_created { get; set; }
    }
}
