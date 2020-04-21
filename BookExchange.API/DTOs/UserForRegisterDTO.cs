using System.ComponentModel.DataAnnotations;

namespace BookExchange.API.DTOs
{
    public class UserForRegisterDTO
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password 6-15 characters")]
        public string Password { get; set; }
    }
}