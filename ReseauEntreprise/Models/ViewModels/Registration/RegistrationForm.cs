using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Réseau_d_entreprise.Models.ViewModels
{
    public class RegistrationForm
    {
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(360)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public String Confirm { get; set; }
        [Required]
        [MaxLength(50)]
        public string RegNat { get; set; }
        [Required]
        public string Address { get; set; }
        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}