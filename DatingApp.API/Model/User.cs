namespace DatingApp.API.Model
{
    public class User
    {
        public int Id { get; set; }
        public int Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
