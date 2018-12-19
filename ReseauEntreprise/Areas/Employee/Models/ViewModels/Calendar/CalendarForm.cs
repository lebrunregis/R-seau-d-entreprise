using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Calendar
{
    public class CalendarForm
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OnClickUrl { get; set; }
        public CalendarForm(string Title,DateTime StartDate, DateTime? EndDate, string OnClickUrl)
        {
            this.Title = Title;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.OnClickUrl = OnClickUrl;
        }
    }
}