using Model.Global.Data;
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
            Command cmd = new Command("SP_CreateProject", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Description);
            cmd.AddParameter("Creator", p.Creator);
            cmd.AddParameter("Project_Manager", ProjectManager);
            return (int?)Connection.ExecuteScalar(cmd);
        }
    }
}
