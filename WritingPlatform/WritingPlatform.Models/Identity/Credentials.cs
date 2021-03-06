﻿using System.ComponentModel.DataAnnotations;

namespace WritingPlatform.Models.Identity
{
    public class Credentials
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
