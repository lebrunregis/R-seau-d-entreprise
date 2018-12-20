using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Profile
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