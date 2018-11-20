using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class EmployeeSelectorForm
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public bool Selected { get; set; }
    }
}