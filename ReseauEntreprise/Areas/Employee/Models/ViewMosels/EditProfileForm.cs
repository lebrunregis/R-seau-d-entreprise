using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models
{
    public class EditProfileForm
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Nom")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Adresse")]
        public string Address { get; set; }

        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Numéro de téléphone")]
        public string Phone { get; set; }
    }
}