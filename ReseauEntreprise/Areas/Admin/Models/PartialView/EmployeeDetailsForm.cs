using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC = System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.PartialView
{
    public class EmployeeDetailsForm
    {
        [MVC.HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
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
        public string Email { get; set; }
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
        [Required]
        public bool IsAdmin { get; set; }
    }
}