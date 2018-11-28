using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Employee
{
    public class DetailsForm
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("National identity number")]
        public string RegNat { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActif { get; set; }
        public IEnumerable<StatusForm> StatusHistory { get; set; }
        public IEnumerable<ProjectManagerStatusForm> ProjectManagerHistory { get; set; }
        public IEnumerable<DepartmentForm> DepartmentHistory { get; set; }
    }
}