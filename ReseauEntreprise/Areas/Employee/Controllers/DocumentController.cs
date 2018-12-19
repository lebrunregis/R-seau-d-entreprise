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
        // GET: Employee/Document/Upload
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(UploadForm form)
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