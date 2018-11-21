using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class CreateForm
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        public String Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentList { get; set; }
        [Required]
        public bool OpenSubscription { get; set; }
    }
}