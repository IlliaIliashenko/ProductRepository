using System;
using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class RegisterUserModel
    {
        [Required]
        [MaxLength(15)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}