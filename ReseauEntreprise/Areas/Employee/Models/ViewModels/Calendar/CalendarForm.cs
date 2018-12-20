using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Calendar
{
    [DataContract]
    public class CalendarForm
    {
        [DataMember]
        [Required]
        public string Title { get; set; }
        [DataMember]
        [Required]
        public string Start { get; set; }
        [DataMember]
        public string End { get; set; }
        [DataMember]
        public bool? AllDay { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string BackgroundColor { get; set; }
        [DataMember]
        public string BorderColor { get; set; }
        [DataMember]
        public string TextColor { get; set; }
    }
}