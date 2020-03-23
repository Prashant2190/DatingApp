using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTO
{
    public class UserToRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(16,MinimumLength = 4, ErrorMessage = "Password Length should be between 4 and 16")]
        public string Password { get; set; }
    }
}