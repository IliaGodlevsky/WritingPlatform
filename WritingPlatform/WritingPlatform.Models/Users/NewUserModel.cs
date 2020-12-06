using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WritingPlatform.Models.Users
{
    public class NewUserModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        public string Login { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 symbols")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirm password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
