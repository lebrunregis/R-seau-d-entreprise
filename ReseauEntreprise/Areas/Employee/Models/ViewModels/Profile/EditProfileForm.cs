using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Profile
{
    public class EditProfileForm
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(7)]
        [DisplayName("Adress")]
        public string Address { get; set; }

        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}