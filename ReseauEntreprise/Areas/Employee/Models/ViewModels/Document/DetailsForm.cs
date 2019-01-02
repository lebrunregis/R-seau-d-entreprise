using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Document
{
    public class DetailsForm
    {
        [HiddenInput]
        public int? Id { get; set; }
        public String Name { get; set; }
        [DisplayName("Date of last modification")]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [DisplayName("Modified by")]
        public C.Employee AuthorEmployee { get; set; }
        public long Size { get; set; }
        [DisplayName("Date of deletion")]
        [DataType(DataType.DateTime)]
        public DateTime? Deleted { get; set; }
    }
}