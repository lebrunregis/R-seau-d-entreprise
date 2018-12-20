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
        string Title { get; set; }
        [DataMember]
        [Required]
        DateTime Start { get; set; }
        [DataMember]
        DateTime End { get; set; }
        [DataMember]
        bool? AllDay { get; set; }
        [DataMember]
        string Url { get; set; }
        [DataMember]
        string BackgroundColor { get; set; }
        [DataMember]
        string BorderColor { get; set; }
        [DataMember]
        string TextColor { get; set; }
    }
}