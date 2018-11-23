using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using D=Model.Global.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee
{
    public class DetailsForm
    {
        [Key]
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
        public bool IsMe { get; set; }
        [DisplayName("Equipes")]
        public IEnumerable<D.Team> Teams { get; set; }
        [DisplayName("Départements")]
        public IEnumerable<D.Department> Departments { get; set; }
        [DisplayName("Chef des équipes")]
        public IEnumerable<D.Team> TeamLeaderTeams { get; set; }
        [DisplayName("Chef des projets")]
        public IEnumerable<D.Project> ProjectManagerProjects { get; set; }
        [DisplayName("Chef des départements")]
        public IEnumerable<D.Department> HeadOfDepartmentDepartments { get; set; }
    }
}