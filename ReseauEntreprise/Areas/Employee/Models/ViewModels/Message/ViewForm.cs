using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class ViewForm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int? Parent { get; set; }
        public C.Employee Author { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreationTime { get; set; }
    }
}