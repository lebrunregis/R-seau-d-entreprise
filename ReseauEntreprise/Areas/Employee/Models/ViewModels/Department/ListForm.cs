using System;
using System.ComponentModel.DataAnnotations;
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