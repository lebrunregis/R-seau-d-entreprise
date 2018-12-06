using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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
        [HiddenInput]
        public int? ToEmployee { get; set; }
        [HiddenInput]
        public int? ToTask { get; set; }
        [HiddenInput]
        public int? ToTeam { get; set; }
        [HiddenInput]
        public int? ToProject { get; set; }
        [HiddenInput]
        public int? ReplyTo { get; set; }
    }
}