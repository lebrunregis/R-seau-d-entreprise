using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    public static class DocumentService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Document doc)
        {

            Command cmd = new Command("UploadFile", true);
            cmd.AddParameter("Employee_Id", doc.AuthorEmployee);
            cmd.AddParameter("Name", doc.Name);
            cmd.AddParameter("Body", doc.Body);
            cmd.AddParameter("Document_Id", doc.Id);

            return (int?)Connection.ExecuteScalar(cmd);
            
        }

        public static Document Get(int Id)
        {
            Command cmd = new Command("DownloadFile", true);
            cmd.AddParameter("DocumentId", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocument()).FirstOrDefault();
        }

        public static bool AddToDepartment(int DocumentId, int DepartmentId)
        {
            Command cmd = new Command("AddDocToDepartment", true);
            cmd.AddParameter("Document_Id", DocumentId);
            cmd.AddParameter("Department_Id", DepartmentId);
            return Connection.ExecuteNonQuery(cmd) > 0;
        }
        public static bool AddToEvent(int DocumentId, int EventId)
        {
            Command cmd = new Command("AddDocToEvent", true);
            cmd.AddParameter("Document_Id", DocumentId);
            cmd.AddParameter("Event_Id", EventId);
            return Connection.ExecuteNonQuery(cmd) > 0;
        }
        public static bool AddToMessage(int DocumentId, int MessageId)
        {
            Command cmd = new Command("AddDocToMessage", true);
            cmd.AddParameter("Document_Id", DocumentId);
            cmd.AddParameter("Message_Id", MessageId);
            return Connection.ExecuteNonQuery(cmd) > 0;
        }
        public static bool AddToProject(int DocumentId, int ProjectId)
        {
            Command cmd = new Command("AddDocToProject", true);
            cmd.AddParameter("Document_Id", DocumentId);
            cmd.AddParameter("Project_Id", ProjectId);
            return Connection.ExecuteNonQuery(cmd) > 0;
        }
        public static bool AddToTask(int DocumentId, int TaskId)
        {
            Command cmd = new Command("AddDocToTask", true);
            cmd.AddParameter("Document_Id", DocumentId);
            cmd.AddParameter("Task_Id", TaskId);
            return Connection.ExecuteNonQuery(cmd) > 0;
        }
        public static bool AddToTeam(int DocumentId, int TeamId)
        {
            Command cmd = new Command("AddDocToTeam", true);
            cmd.AddParameter("Document_Id", DocumentId);
            cmd.AddParameter("Team_Id", TeamId);
            return Connection.ExecuteNonQuery(cmd) > 0;
        }
        public static IEnumerable<Document> GetForDepartment(int Id)
        {
            Command cmd = new Command("GetDocsForDepartment", true);
            cmd.AddParameter("Department_Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocumentSimplified());
        }
        public static IEnumerable<Document> GetForEvent(int Id)
        {
            Command cmd = new Command("GetDocsForEvent", true);
            cmd.AddParameter("Event_Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocumentSimplified());
        }
        public static IEnumerable<Document> GetForMessage(int Id)
        {
            Command cmd = new Command("GetDocsForMessage", true);
            cmd.AddParameter("Message_Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocumentSimplified());
        }
        public static IEnumerable<Document> GetForProject(int Id)
        {
            Command cmd = new Command("GetDocsForProject", true);
            cmd.AddParameter("Project_Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocumentSimplified());
        }
        public static IEnumerable<Document> GetForTask(int Id)
        {
            Command cmd = new Command("GetDocsForTask", true);
            cmd.AddParameter("Task_Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocumentSimplified());
        }
        public static IEnumerable<Document> GetForTeam(int Id)
        {
            Command cmd = new Command("GetDocsForTeam", true);
            cmd.AddParameter("Team_Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDocumentSimplified());
        }
    }
}
