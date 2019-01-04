using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Calendar
{
    [DataContract]
    public class CalendarForm
    {

        private bool _allDay = true;

        [DataMember]
        [Required]
        [JsonProperty("id")]
        public int Id { get; set; }
        [DataMember]
        [Required]
        [JsonProperty("title")]
        public string Title { get; set; }
        [DataMember]
        [Required]
        [JsonProperty("start")]
        public DateTime Start { get; set; }
        [DataMember]
        [JsonProperty("end")]
        public DateTime End { get; set; }
        [DataMember]
        [JsonProperty("url")]
        public string Url { get; set; }
        [DataMember]
        [JsonProperty("allday")]
        bool AllDay 
        { get => _allDay; set => _allDay = value; }
    }
}