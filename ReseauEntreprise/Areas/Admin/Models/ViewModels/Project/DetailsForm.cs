using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Project
{
    public class DetailsForm
    {

        [MaxLength(50)]
        public String Name { get; set; }

        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Display(Name = "Project Manager")]
        public D.Employee Manager { get; set; }
        public List<D.Team> Teams { get; set; }

    }
}