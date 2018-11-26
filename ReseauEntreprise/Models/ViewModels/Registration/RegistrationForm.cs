﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Réseau_d_entreprise.Models.ViewModels
{
    public class RegistrationForm
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(360)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public String Confirm { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("National Number")]
        public string RegNat { get; set; }
        [Required]
        [MinLength(7)]
        [DisplayName("Adress")]
        public string Address { get; set; }
        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
    }
}