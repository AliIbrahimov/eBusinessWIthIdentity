using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace eBusiness.ViewModels
{
    public class RegisterVM
    {
        [Required,MinLength(8),MaxLength(50)]
        public string Username { get; set; }
        public string Fullname { get; set; }
        [RequiredAttribute,EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password),MinLength(8)]
        public string Password { get; set; }
        [DataType(DataType.Password), MaxLength(30),Compare(nameof(Password))]

        public string ConfirmedPassword { get; set; }
    }
}
