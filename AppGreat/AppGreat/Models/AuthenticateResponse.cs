namespace AppGreat.Models
{
    using AppGreat.Data.Models;
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Token = token;         
        }
    }
}
