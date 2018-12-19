using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Document
{
    public class UploadForm
    {
        public int? PreviousVersionId {get; set;}

        [DataType(DataType.Upload)]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}