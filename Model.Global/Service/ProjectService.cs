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
            cmd.AddParameter("Creator", p.CreatorId);
            cmd.AddParameter("Project_Manager", ProjectManager);
            cmd.AddParameter("StartDate", p.Start);
            cmd.AddParameter("EndDate", p.End);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static bool Edit(int User,Project p)
        {
            Command cmd = new Command("EditProject", true);
            cmd.AddParameter("User", User);
            cmd.AddParameter("Project", p.Id);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Description);
            cmd.AddParameter("CreatorId", p.CreatorId);
            cmd.AddParameter("Project_Manager", p.ProjectManagerId);
            cmd.AddParameter("StartDate", p.Start);
            cmd.AddParameter("EndDate", p.End);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool Delete(Project p,int User)
        {
            Command cmd = new Command("DeleteProject", true);
            cmd.AddParameter("User", User);
            cmd.AddParameter("Id", p.Id);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Description);
            cmd.AddParameter("Creator", p.CreatorId);
            cmd.AddParameter("StartDate", p.Start);
            cmd.AddParameter("EndDate", p.End);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static Data.Project GetProjectById(int ProjectId)
        {
            Command cmd = new Command("GetProject", true);
            cmd.AddParameter("Id", ProjectId);
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

        public static IEnumerable<Data.Team> GetAllTeamsForProject(int ProjectId)
        {
            Command cmd = new Command("GetAllTeamsForProject", true);
            cmd.AddParameter("Project_Id", ProjectId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam());
        }
        public static IEnumerable<Data.Project> GetActiveProjectsForManager(int Manager_Id)
        {
            Command cmd = new Command("GetActiveProjectsForManager", true);
            cmd.AddParameter("Manager_Id", Manager_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToProject());
        }
    }
}
