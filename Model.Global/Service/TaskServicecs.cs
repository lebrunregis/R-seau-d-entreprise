using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    class TaskServicecs
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Task t,int UserId )
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", t.Name);
            cmd.AddParameter("Description", t.Name);
            cmd.AddParameter("StartDate", t.Name);
            cmd.AddParameter("EndDate", t.Name);
            cmd.AddParameter("DeadLine", t.Name);
            cmd.AddParameter("SubtaskOf", t.Name);
            cmd.AddParameter("UserId", t.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Get(int id, int UserId)
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Name);
            cmd.AddParameter("StartDate", p.Name);
            cmd.AddParameter("EndDate", p.Name);
            cmd.AddParameter("DeadLine", p.Name);
            cmd.AddParameter("SubtaskOf", p.Name);
            cmd.AddParameter("UserId", p.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? GetSubtasks(Task p, int UserId)
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Name);
            cmd.AddParameter("StartDate", p.Name);
            cmd.AddParameter("EndDate", p.Name);
            cmd.AddParameter("DeadLine", p.Name);
            cmd.AddParameter("SubtaskOf", p.Name);
            cmd.AddParameter("UserId", p.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? GetForProject(Task p, int UserId)
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Name);
            cmd.AddParameter("StartDate", p.Name);
            cmd.AddParameter("EndDate", p.Name);
            cmd.AddParameter("DeadLine", p.Name);
            cmd.AddParameter("SubtaskOf", p.Name);
            cmd.AddParameter("UserId", p.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? GetStatus(Task p, int UserId)
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Name);
            cmd.AddParameter("StartDate", p.Name);
            cmd.AddParameter("EndDate", p.Name);
            cmd.AddParameter("DeadLine", p.Name);
            cmd.AddParameter("SubtaskOf", p.Name);
            cmd.AddParameter("UserId", p.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Update(Task p, int UserId)
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Name);
            cmd.AddParameter("StartDate", p.Name);
            cmd.AddParameter("EndDate", p.Name);
            cmd.AddParameter("DeadLine", p.Name);
            cmd.AddParameter("SubtaskOf", p.Name);
            cmd.AddParameter("UserId", p.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? AssignEmployee(Task p, int UserId)
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Name);
            cmd.AddParameter("StartDate", p.Name);
            cmd.AddParameter("EndDate", p.Name);
            cmd.AddParameter("DeadLine", p.Name);
            cmd.AddParameter("SubtaskOf", p.Name);
            cmd.AddParameter("UserId", p.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Delete(Task p, int UserId)
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", p.Name);
            cmd.AddParameter("Description", p.Name);
            cmd.AddParameter("StartDate", p.Name);
            cmd.AddParameter("EndDate", p.Name);
            cmd.AddParameter("DeadLine", p.Name);
            cmd.AddParameter("SubtaskOf", p.Name);
            cmd.AddParameter("UserId", p.Name);
            return (int?)Connection.ExecuteScalar(cmd);
        }
    }
}
