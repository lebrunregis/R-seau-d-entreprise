using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Global.Data;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Team
{
    public class DeleteForm
    {
        [Key]
        [HiddenInput]
        [Editable(false)]
        public int TeamId { get; set; }
        [Required]
        [MaxLength(50)]
        [Editable(false)]
        public String Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Editable(false)]
        public DateTime DateCreated { get; set; }
    }
}