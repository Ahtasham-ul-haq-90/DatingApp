using System.ComponentModel.DataAnnotations;

namespace DatingAPP_API.DTO
{
    public class UserRegisterDTO
    {
        [EmailAddress]
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        
        public string Password { get; set; }
    }
}
