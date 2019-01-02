using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Document
{
    public class UploadForm
    {
        public int? PreviousVersionId { get; set; }

        public int? DepartmentId { get; set; }
        public int? EventId { get; set; }
        public int? MessageId { get; set; }
        public int? ProjectId { get; set; }
        public int? TaskId { get; set; }
        public int? TeamId { get; set; }

        [DataType(DataType.Upload)]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}