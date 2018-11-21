using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class DeleteForm
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int CreatorId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [Required]
        public bool OpenSubscription { get; set; }
    }
}