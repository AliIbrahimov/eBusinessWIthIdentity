using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace eBusiness.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password), MinLength(8)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
