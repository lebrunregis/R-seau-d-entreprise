using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using C = Model.Client.Data;

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
        public C.Employee HeadOfDepartment { get; set; }
    }
}