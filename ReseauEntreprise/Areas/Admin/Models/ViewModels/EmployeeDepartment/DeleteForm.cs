using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.EmployeeDepartment
{
    public class DeleteForm
    {
        public int SelectedEmployeeId { get; set; }
        public int SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
    }
}