using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using G = Model.Global.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Department
{
    public class CreateForm
    {
        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Head of department")]
        public int SelectedHeadOfDepartmentId { get; set; }
        public IEnumerable<SelectListItem> HeadOfDepartmentCandidateList { get; set; }
    }
}