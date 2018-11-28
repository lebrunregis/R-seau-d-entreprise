using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using G = Model.Global.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Department
{
    public class ListForm
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public String Description { get; set; }
        [Display(Name= "Head of Department")]
        public G.Employee HeadOfDepartment { get; set; }
    }
}