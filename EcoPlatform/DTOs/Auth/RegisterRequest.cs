using System.ComponentModel.DataAnnotations;

namespace EcoPlatform.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
