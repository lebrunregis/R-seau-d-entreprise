using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Department
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
        public C.Employee Creator { get; set; }
        [Display(Name = "Head of Department")]
        public C.Employee HeadOfDepartment { get; set; }
        public IEnumerable<C.Employee> Employees { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}