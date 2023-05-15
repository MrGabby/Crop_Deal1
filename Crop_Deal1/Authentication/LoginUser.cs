namespace Crop_Deal1.Authentication
{
    public class LoginUser
    { 
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

}
