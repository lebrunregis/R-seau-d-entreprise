using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations ;
using System.Linq;
using System.Web;
using MVC=System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Employee
{
    public class EditForm
    {
        [MVC.HiddenInput]
        [Key]
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
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [DisplayName("Confirm password")]
        public String Confirm { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("National identity number")]
        public string RegNat { get; set; }
        [Required]
        [MinLength(7)]
        public string Address { get; set; }
        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}