using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Employee
{
    public class ListForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("National identity number")]
        public string RegNat { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
    }
}