using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class CreateForm
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}