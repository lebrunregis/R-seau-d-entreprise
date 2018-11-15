using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.EmployeeDepartment
{
    public class DeleteForm
    {
        [HiddenInput]
        [Key]
        public int SelectedEmployeeId { get; set; }
        [HiddenInput]
        [Key]
        public int SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}