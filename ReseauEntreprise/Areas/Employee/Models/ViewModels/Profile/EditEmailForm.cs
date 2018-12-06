using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Profile
{
    public class EditEmailForm
    {
        [Required]
        [MinLength(5)]
        [MaxLength(360)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Nouveau email")]
        public String Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(50)]
        [DisplayName("Mot de passe")]
        public String Passwd { get; set; }
    }
}