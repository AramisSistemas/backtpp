using System.ComponentModel.DataAnnotations;

namespace Repository.Modelsdtos.Users
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}