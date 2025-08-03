using System.ComponentModel.DataAnnotations;

namespace DatingAPP_API.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
