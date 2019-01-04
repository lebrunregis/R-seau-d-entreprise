using System.ComponentModel.DataAnnotations;
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