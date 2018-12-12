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
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [DisplayName("Ancien mot de passe")]
        public String OldPass { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [DisplayName("Nouveau mot de passe")]
        public String NewPass { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPass))]
        [DisplayName("Retapez nouveau mot de passe")]
        public String Confirm { get; set; }
    }
}