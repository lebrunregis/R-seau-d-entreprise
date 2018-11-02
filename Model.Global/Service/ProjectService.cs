using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    public static class ProjectService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Project p, int ProjectManager)
        {
            Command cmd = new Command("CreateProject", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Description);
            cmd.AddParameter("Creator", p.Creator);
            cmd.AddParameter("Project_Manager", ProjectManager);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Edit(Project p, int ProjectManager)
        {
            Command cmd = new Command("EditProject", true);
            cmd.AddParameter("Id", p.Id);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Description);
            cmd.AddParameter("Creator", p.Creator);
            cmd.AddParameter("Project_Manager", ProjectManager);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Delete(Project p, int ProjectManager)
        {
            Command cmd = new Command("DeleteProject", true);
            cmd.AddParameter("Id", p.Id);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Description);
            cmd.AddParameter("Creator", p.Creator);
            cmd.AddParameter("Project_Manager", ProjectManager);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static Data.Project GetProjectById(int ProjectId)
        {
            Command cmd = new Command("GetProject", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToProject()).FirstOrDefault();
        }

        public static IEnumerable<Data.Project> GetAllActive()
        {
            Command cmd = new Command("GetAllActiveProjects", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToProject());
        }

        public static IEnumerable<Data.Project> GetAll()
        {
            Command cmd = new Command("GetAllProjects", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToProject());
        }
        public static int? GetProjectManagerId(int ProjectId)
        {
            Command cmd = new Command("GetProjectManagerId", true);
            cmd.AddParameter("ProjectId", ProjectId); 
            return (int?) Connection.ExecuteScalar(cmd);
        }
    }
}
