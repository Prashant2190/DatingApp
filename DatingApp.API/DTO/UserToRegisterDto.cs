using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTO
{
    public class UserToRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8,MinimumLength = 4, ErrorMessage = "Password Length should be between 4 and 8")]
        public string Password { get; set; }
    }
}