using Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using System.IO;
using System.Linq;
using System.Web;
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
                    Filename = Path.GetFileName(form.File.FileName),
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
                        return RedirectToAction("Details", "Department", new { id = form.DepartmentId });
                    }
                    else if (form.EventId != null)
                    {
                        DocumentService.AddToEvent((int)DocumentId, (int)form.EventId);
                        return RedirectToAction("Details", "Event", new { id = form.EventId });
                    }
                    else if (form.MessageId != null)
                    {
                        DocumentService.AddToMessage((int)DocumentId, (int)form.MessageId);
                    }
                    else if (form.ProjectId != null)
                    {
                        DocumentService.AddToProject((int)DocumentId, (int)form.ProjectId);
                        return RedirectToAction("Details", "Project", new { projectId = form.ProjectId });
                    }
                    else if (form.TaskId != null)
                    {
                        DocumentService.AddToTask((int)DocumentId, (int)form.TaskId);
                        return RedirectToAction("Details", "Task", new { taskId = form.TaskId });
                    }
                    else if (form.TeamId != null)
                    {
                        DocumentService.AddToTeam((int)DocumentId, (int)form.TeamId);
                        return RedirectToAction("Details", "Team", new { teamId = form.TeamId });
                    }
                    else if (form.PreviousVersionId != null)
                    {
                        return RedirectToAction("Details", "Document", new { id = form.PreviousVersionId });
                    }
                }
            }
            return RedirectToAction("Index", "Employee");
        }
        public FileResult Download(int id)
        {
            Document doc = DocumentService.Get(id);
            return File(doc.Body, System.Net.Mime.MediaTypeNames.Application.Octet, doc.Filename);
        }
        public ActionResult Details(int id)
        {
            Document doc = new Document();
            doc = DocumentService.GetForDescription(id);
            DetailsForm form = new DetailsForm
            {
                Id = doc.Id,
                Name = doc.Filename,
                AuthorEmployee = EmployeeService.Get(doc.AuthorEmployee),
                Deleted = doc.Deleted,
                Created = doc.Created,
                Size = doc.Size
            };
            return View(form);

        }

        public ActionResult Delete(int id)
        {
            Document doc = new Document();
            doc = DocumentService.GetForDescription(id);
            DetailsForm form = new DetailsForm
            {
                Id = doc.Id,
                Name = doc.Filename,
                AuthorEmployee = EmployeeService.Get(doc.AuthorEmployee),
                Deleted = doc.Deleted,
                Created = doc.Created,
                Size = doc.Size
            };
            return View(form);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form) // FormCollection just pour differencier
        {
            DocumentService.Delete(id, SessionUser.GetUser().Id);
            return RedirectToAction("Index", "Employee");
        }
    }
}