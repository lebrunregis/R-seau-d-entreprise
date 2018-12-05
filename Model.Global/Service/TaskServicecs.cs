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
    public class TaskService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Task t,int UserId )
        {
            Command cmd = new Command("CreateTask", true);
            cmd.AddParameter("Name", t.Name);
            cmd.AddParameter("Description", t.Description);
            cmd.AddParameter("StartDate", t.StartDate);
            cmd.AddParameter("EndDate", t.EndDate);
            cmd.AddParameter("DeadLine", t.Deadline);
            cmd.AddParameter("SubtaskOf", t.SubtaskOf);
            cmd.AddParameter("UserId",UserId);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static Task Get(int id, int UserId)
        {
            Command cmd = new Command("GetTask", true);
            cmd.AddParameter("Id", id);
            cmd.AddParameter("UserId", UserId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTask()).FirstOrDefault();
        }

        public static IEnumerable<Task> GetSubtasks(Task t, int UserId)
        {
            Command cmd = new Command("GetSubtasks", true);
            cmd.AddParameter("Id", t.Id);
            cmd.AddParameter("UserId", UserId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTask());
        }

        public static IEnumerable<Task> GetForTeam(int teamId, int userId)
        {
            Command cmd = new Command("GetTasksForProject", true);
            cmd.AddParameter("TeamId", teamId);
            cmd.AddParameter("UserId", userId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTask());
        }

        public static IEnumerable<Task> GetForUser( int UserId)
        {
            Command cmd = new Command("GetTasksForUser", true);
            cmd.AddParameter("UserId", UserId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTask());
        }

        public static IEnumerable<Task> GetForProject(int projectId, int UserId)
        {
            Command cmd = new Command("GetTasksForProject", true);
            cmd.AddParameter("ProjectId", projectId);
            cmd.AddParameter("UserId", UserId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTask());
        }

        public static bool SetStatus(Task t, int Status,int UserId)
        {
            Command cmd = new Command("SetTaskStatus", true);
            cmd.AddParameter("IdTask", t.Id);
            cmd.AddParameter("IdStatus", UserId);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool Update(Task t, int UserId)
        {
            Command cmd = new Command("UpdateTask", true);
            cmd.AddParameter("Id", t.Id);
            cmd.AddParameter("Name", t.Name);
            cmd.AddParameter("Description", t.Description);
            cmd.AddParameter("StartDate", t.StartDate);
            cmd.AddParameter("EndDate", t.EndDate);
            cmd.AddParameter("DeadLine", t.Deadline);
            cmd.AddParameter("SubtaskOf", t.SubtaskOf);
            cmd.AddParameter("UserId", UserId);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static IEnumerable<TaskStatus> GetStatusList()
        {
            Command cmd = new Command("GetTaskStatusList", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTaskStatus());
        }

        public static bool AssignEmployee(Task t, int UserId)
        {
            Command cmd = new Command("AssignEmployeeToTask", true);
            cmd.AddParameter("Name", t.Name);
            cmd.AddParameter("Description", t.Name);
            cmd.AddParameter("StartDate", t.Name);
            cmd.AddParameter("EndDate", t.Name);
            cmd.AddParameter("DeadLine", t.Name);
            cmd.AddParameter("SubtaskOf", t.Name);
            cmd.AddParameter("UserId", t.Name);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool Delete(Task t, int UserId)
        {
            Command cmd = new Command("DeleteTask", true);
            cmd.AddParameter("Id", t.Id);
            cmd.AddParameter("Name", t.Name);
            cmd.AddParameter("Description", t.Description);
            cmd.AddParameter("StartDate", t.StartDate);
            cmd.AddParameter("EndDate", t.EndDate);
            cmd.AddParameter("DeadLine", t.Deadline);
            cmd.AddParameter("SubtaskOf", t.SubtaskOf);
            cmd.AddParameter("UserId", UserId);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static IEnumerable<TaskStatusHistory>  GetTaskStatusesHistory(Task t, int UserId)
        {
            Command cmd = new Command("GetTaskStatusesHistory", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTaskStatusHistory());
        }

        public static bool SetTaskStatus(Task t, TaskStatus status,int UserId)
        {
            Command cmd = new Command("SetTaskStatus", true);
            cmd.AddParameter("TaskId", t.Id);
            cmd.AddParameter("StatusId", status.Id);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
    }
}
