using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using C = Model.Client.Data;
using Doc = ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Message
{
    public class ViewForm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        public int? Parent { get; set; }
        public C.Employee Author { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreationTime { get; set; }
        public IEnumerable<ViewForm> Children { get; set; }
        public IEnumerable<Doc.ListForm> Documents { get; set; }

        public ViewForm() { }

        public ViewForm(C.Message message) : this(message, null)
        {
        }

        public ViewForm(C.Message message, IEnumerable<ViewForm> Children)
        {
            Id = (int)message.Id;
            Title = message.Title;
            Message = message.Body;
            Parent = message.Parent;
            Author = EmployeeService.Get(message.Author);
            CreationTime = message.Created;
            Documents = DocumentService.GetForMessage((int)message.Id).Select(d => new Doc.ListForm { Name = d.Name, Id = (int)d.Id});
            this.Children = Children;
        }
    }
}