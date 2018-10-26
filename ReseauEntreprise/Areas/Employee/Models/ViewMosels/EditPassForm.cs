using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models
{
    public class EditPassForm
    {
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(50)]
        [DisplayName("Ancien mot de passe")]
        public String OldPass { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(50)]
        [DisplayName("Nouveau mot de passe")]
        public String NewPass { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare(nameof(NewPass))]
        [DisplayName("Retapez nouveau mot de passe")]
        public String Confirm { get; set; }
    }
}