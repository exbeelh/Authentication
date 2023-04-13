﻿using System.ComponentModel.DataAnnotations;

namespace Exercise.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email Address"), EmailAddress]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        
        public string ReturnUrl { get; set; } = null!;
    }
}
