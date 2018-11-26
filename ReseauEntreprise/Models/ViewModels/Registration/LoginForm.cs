using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Réseau_d_entreprise.Models.ViewModels
{
    public class LoginForm
    {
        [Required]
        [MinLength(5)]
        [MaxLength(360)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail")]
        public String Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(50)]
        [DisplayName("Password")]
        public String Passwd { get; set; }
    }
}