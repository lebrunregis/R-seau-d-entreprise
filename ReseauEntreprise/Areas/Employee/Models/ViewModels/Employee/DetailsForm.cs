using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee
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
        [DisplayName("Adresse")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActif { get; set; }
        public bool IsMe { get; set; }
        public IEnumerable<D.Team> Teams { get; set; }
        public IEnumerable<D.Department> Departments { get; set; }
        [DisplayName("Team leader of teams:")]
        public IEnumerable<D.Team> TeamLeaderTeams { get; set; }
        [DisplayName("Project manager of projects:")]
        public IEnumerable<D.Project> ProjectManagerProjects { get; set; }
        [DisplayName("Head of departments:")]
        public IEnumerable<D.Department> HeadOfDepartmentDepartments { get; set; }
        public bool CanIAddToDepartment { get; set; }
        public bool CanIRemoveFromDepartment { get; set; }

        public Message.DiscussionScriptForm DiscScriptForm { get; set; }
    }
}