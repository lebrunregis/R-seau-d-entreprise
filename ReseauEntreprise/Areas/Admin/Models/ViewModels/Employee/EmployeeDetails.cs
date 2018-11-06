using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Employee
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        [DisplayName("Nom")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Numéro de registre national")]
        public string RegNat { get; set; }
        [DisplayName("Adresse")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Numéro de téléphone")]
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<EmployeeStatus> StatusHistory { get; set; }
        public IEnumerable<ProjectManagerStatus> ProjectManagerHistory { get; set; }
    }
}