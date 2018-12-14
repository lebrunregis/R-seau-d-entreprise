using Model.Client.Data;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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

                byte[] firstPart;
                if (file.Length <= 8000)
                {
                    firstPart = file;
                }
                else
                {
                    firstPart = new ArraySegment<byte>(file, 0, 8000).ToArray();
                }


                Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
                Command cmd = new Command("UploadFile", true);
                cmd.AddParameter("Employee_Id", SessionUser.GetUser().Id);
                cmd.AddParameter("Name", form.File.FileName);
                cmd.AddParameter("Body", firstPart);
                int id = (int)Connection.ExecuteScalar(cmd);

                int count = 8000;
                for (int i = 8000; i < file.Length; i += 8000)
                {
                    if (file.Length - i < 8000)
                    {
                        count = file.Length - i;
                    }
                    cmd = new Command("ContinueUploadingFile", true);
                    cmd.AddParameter("Id", id);
                    cmd.AddParameter("Body", new ArraySegment<byte>(file, i, count).ToArray());
                    Connection.ExecuteNonQuery(cmd);
                }
            }
            return View();
        }
        public FileResult Download(int id)
        {
            Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            Command cmd = new Command("DownloadFile", true);
            cmd.AddParameter("DocumentId", id);
            Document doc = Connection.ExecuteReader(cmd, dr => new Document {Body=(byte[])dr["Body"], Name = (string)dr["Name"] }).FirstOrDefault();
            return File(doc.Body, System.Net.Mime.MediaTypeNames.Application.Octet, doc.Name);
        }
    }
}