using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.EmployeeDepartment
{
    public class RemoveEmployeeFromDepartmentForm
    {
        [Required]
        [HiddenInput]
        [Key]
        [Display(Name = "Employee Id")]
        public int SelectedEmployeeId { get; set; }
        [HiddenInput]
        [Key]
        [Required]
        [Display(Name = "Department Id")]
        public int SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}