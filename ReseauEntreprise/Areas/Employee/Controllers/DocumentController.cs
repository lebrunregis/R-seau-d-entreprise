using Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [EmployeeRequired]
    public class DocumentController : Controller
    {
        [ChildActionOnly]
        public ActionResult _Upload(int? DepartmentId, int? EventId, int? MessageId, int? ProjectId, int? TaskId, int? TeamId, int? DocumentId)
        {
            UploadForm form = new UploadForm
            {
                DepartmentId = DepartmentId,
                EventId = EventId,
                MessageId = MessageId,
                ProjectId = ProjectId,
                TaskId = TaskId,
                TeamId = TeamId,
                PreviousVersionId = DocumentId
            };
            return PartialView(form);
        }

        [HttpPost]
        public ActionResult _Upload(UploadForm form)
        {
            if (ModelState.IsValid)
            {
                byte[] file = new byte[form.File.ContentLength];
                form.File.InputStream.Read(file, 0, file.Length);
                
                Document doc = new Document
                {
                    Name = Path.GetFileName(form.File.FileName),
                    Body = file,
                    AuthorEmployee = SessionUser.GetUser().Id
                };
                if (form.PreviousVersionId.HasValue)
                {
                    doc.Id = form.PreviousVersionId;
                }
                int? DocumentId = DocumentService.Create(doc);
                if (DocumentId != null)
                {
                    if (form.DepartmentId != null)
                    {
                        DocumentService.AddToDepartment((int)DocumentId, (int)form.DepartmentId);
                    }
                    if (form.EventId != null)
                    {
                        DocumentService.AddToEvent((int)DocumentId, (int)form.EventId);
                    }
                    if (form.MessageId != null)
                    {
                        DocumentService.AddToMessage((int)DocumentId, (int)form.MessageId);
                    }
                    if (form.ProjectId != null)
                    {
                        DocumentService.AddToProject((int)DocumentId, (int)form.ProjectId);
                    }
                    if (form.TaskId != null)
                    {
                        DocumentService.AddToTask((int)DocumentId, (int)form.TaskId);
                    }
                    if (form.TeamId != null)
                    {
                        DocumentService.AddToTeam((int)DocumentId, (int)form.TeamId);
                    }
                }
            }
            return PartialView();
        }
        public FileResult Download(int id)
        {
            Document doc = DocumentService.Get(id);
            return File(doc.Body, System.Net.Mime.MediaTypeNames.Application.Octet, doc.Name);
        }
        public ActionResult Details(int DocumentId)
        {
            return View();
        }
    }
}