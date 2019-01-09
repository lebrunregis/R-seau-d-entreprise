using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class SendForm
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        public int? ToEmployee { get; set; }
        public int? ToTask { get; set; }
        public int? ToTeam { get; set; }
        public int? ToProject { get; set; }
        [HiddenInput]
        public int? ReplyTo { get; set; }
    }
}