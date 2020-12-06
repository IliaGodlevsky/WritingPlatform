using System.ComponentModel.DataAnnotations;

namespace WritingPlatform.Models.Identity
{
    public class ChangePasswordModel
    {
        public int UserId { get; set; }

        [Display(Name = "Old password")]
        [MinLength(length:6, ErrorMessage = "Too short password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        public string OldPassword { get; set; }

        [Display(Name = "New password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
