using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolBox.DBTools;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Employee/Document
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(UploadForm form) //UploadForm
        {
            if (ModelState.IsValid)
            {
                byte[] file;
                using (Stream stream = form.File.InputStream)
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        file = reader.ReadBytes((int)stream.Length);
                    }
                }


                Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
                Command cmd = new Command("UploadFile", true);
                cmd.AddParameter("Employee_Id", SessionUser.GetUser().Id);
                cmd.AddParameter("Name", form.File.FileName);
                cmd.AddParameter("Body", file);
                Connection.ExecuteNonQuery(cmd);
            }
            return View();
        }
    }
}