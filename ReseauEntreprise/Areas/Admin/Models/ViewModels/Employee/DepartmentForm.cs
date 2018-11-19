using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Employee
{
    public class DepartmentForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmpId { get; set; }
        [Required]
        public int DepId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}