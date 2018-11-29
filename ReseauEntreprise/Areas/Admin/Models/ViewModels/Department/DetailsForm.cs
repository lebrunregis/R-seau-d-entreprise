using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Department
{
    public class DetailsForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public String Description { get; set; }
        [HiddenInput]
        [Required]
        public int Admin_Id { get; set; }
        [HiddenInput]
        public C.Employee Admin { get; set; }
        [Required]
        public bool Active { get; set; }
        public C.Employee HeadOfDepartment { get; set; }
        public IEnumerable<C.Employee> Employees { get; set; }
    }
}