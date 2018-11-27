using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using G = Model.Global.Data;

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
        public G.Employee Admin { get; set; }
        public G.Employee HeadOfDepartment { get; set; }
        public IEnumerable<G.Employee> Employees { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}