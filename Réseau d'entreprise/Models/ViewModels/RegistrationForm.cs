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
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Confirm { get; set; }
        [Required]
        public string RegNat { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}