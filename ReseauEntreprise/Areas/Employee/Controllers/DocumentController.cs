using Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    public class DocumentController : Controller
    {
        [ChildActionOnly]
        public ActionResult _Upload(int? ProjectId, int? TaskId, int? TeamId, int? EmployeeId)
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _Upload(UploadForm form, int? DepartmentId, int? EventId, int? MessageId, int? ProjectId, int? TaskId, int? TeamId)
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
                DocumentService.Create(doc);
            }
            return View();
        }
        public FileResult Download(int id)
        {
            Document doc = DocumentService.Get(id);
            return File(doc.Body, System.Net.Mime.MediaTypeNames.Application.Octet, doc.Name);
        }
    }
}