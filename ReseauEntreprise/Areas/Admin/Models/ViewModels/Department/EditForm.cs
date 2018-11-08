using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using G = Model.Global.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Department
{
    public class EditForm
    {
        [HiddenInput]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Title { get; set; }
        [HiddenInput]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public String Description { get; set; }
        [HiddenInput]
        [Required]
        public int Admin_Id { get; set; }
        [HiddenInput]
        public G.Employee Admin { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}