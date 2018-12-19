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
    public static class MessageService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Message message, int? employee, int? project, int? task, int? team)
        {
            Command cmd = new Command("CreateMessage", true);
            cmd.AddParameter("title", message.Title);
            cmd.AddParameter("message", message.Body);
            cmd.AddParameter("author", message.Author);
            cmd.AddParameter("parent", message.Parent);
            cmd.AddParameter("receiver_employee", employee);
            cmd.AddParameter("receiver_project", project);
            cmd.AddParameter("receiver_task", task);
            cmd.AddParameter("receiver_team", team);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static Message Get(int id)
        {
            Command cmd = new Command("GetMessage", true);
            cmd.AddParameter("id", id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage()).FirstOrDefault();
        }

        public static IEnumerable<Message> GetProjectMessages(int ProjectId)
        {
            Command cmd = new Command("GetProjectMessages", true);
            cmd.AddParameter("ProjectId", ProjectId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetTaskMessages(int TaskId)
        {
            Command cmd = new Command("GetTaskMessages", true);
            cmd.AddParameter("TaskId", TaskId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetTeamMessages(int TeamId)
        {
            Command cmd = new Command("GetTeamMessages", true);
            cmd.AddParameter("TeamId", TeamId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetMyDiscussionWithEmployee(int MyId, int EmployeeId)
        {
            Command cmd = new Command("GetMyDiscussionWithEmployee", true);
            cmd.AddParameter("MyId", MyId);
            cmd.AddParameter("EmployeeId", EmployeeId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }
        public static IEnumerable<Message> GetProjectMessagesWithoutSome(int ProjectId, int max_id)
        {
            Command cmd = new Command("GetProjectMessagesWithoutSome", true);
            cmd.AddParameter("ProjectId", ProjectId);
            cmd.AddParameter("max_id", max_id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetTaskMessagesWithoutSome(int TaskId, int max_id)
        {
            Command cmd = new Command("GetTaskMessagesWithoutSome", true);
            cmd.AddParameter("TaskId", TaskId);
            cmd.AddParameter("max_id", max_id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetTeamMessagesWithoutSome(int TeamId, int max_id)
        {
            Command cmd = new Command("GetTeamMessagesWithoutSome", true);
            cmd.AddParameter("TeamId", TeamId);
            cmd.AddParameter("max_id", max_id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetMyDiscussionWithEmployeeWithoutSome(int MyId, int EmployeeId, int max_id)
        {
            Command cmd = new Command("GetMyDiscussionWithEmployeeWithoutSome", true);
            cmd.AddParameter("MyId", MyId);
            cmd.AddParameter("EmployeeId", EmployeeId);
            cmd.AddParameter("max_id", max_id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetResponsesToEmployee(int EmployeeId)
        {
            Command cmd = new Command("GetResponsesToEmployee", true);
            cmd.AddParameter("EmployeeId", EmployeeId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Message> GetResponsesToEmployeeWithoutSome(int EmployeeId, int max_id)
        {
            Command cmd = new Command("GetResponsesToEmployeeWithoutSome", true);
            cmd.AddParameter("EmployeeId", EmployeeId);
            cmd.AddParameter("max_id", max_id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToMessage());
        }

        public static IEnumerable<Project> GetProjectForMessage(int MessageId)
        {
            Command cmd = new Command("GetProjectForMessage", true);
            cmd.AddParameter("MessageId", MessageId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToProject());
        }
        public static IEnumerable<Team> GetTeamForMessage(int MessageId)
        {
            Command cmd = new Command("GetTeamForMessage", true);
            cmd.AddParameter("MessageId", MessageId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam());
        }
        public static IEnumerable<Task> GetTaskForMessage(int MessageId)
        {
            Command cmd = new Command("GetTaskForMessage", true);
            cmd.AddParameter("MessageId", MessageId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTask());
        }
        public static bool IsMessageRepliedByEmployee(int MessageId, int EmployeeId)
        {
            Command cmd = new Command("IsMessageRepliedByEmployee", true);
            cmd.AddParameter("MessageId", MessageId);
            cmd.AddParameter("EmployeeId", EmployeeId);
            return (bool)Connection.ExecuteScalar(cmd);
        }
    }
}
