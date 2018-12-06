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
    public class EventService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int Create(Event e,int UserId)
        {
            Command cmd = new Command("CreateEvent", true);
            cmd.AddParameter("Name", e.Name);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Description", e.Description);
            cmd.AddParameter("StartDate", e.StartDate);
            cmd.AddParameter("EndDate", e.EndDate);
            cmd.AddParameter("DepartmentId", e.DepartmentId);
            cmd.AddParameter("Open", e.Open);
            cmd.AddParameter("AdminId", UserId);
            return (Connection.ExecuteNonQuery(cmd));
        }

        public static bool Edit(Event e, int UserId)
        {
            Command cmd = new Command("UpdateEvent", true);
            cmd.AddParameter("Id", e.Id);
            cmd.AddParameter("Name", e.Name);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Description", e.Description);
            cmd.AddParameter("StartDate", e.StartDate);
            cmd.AddParameter("EndDate", e.EndDate);
            cmd.AddParameter("DepartmentId", e.DepartmentId);
            cmd.AddParameter("Open", e.Open);
            cmd.AddParameter("AdminId", UserId);

            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool Delete(Event e, int UserId)
        {
            Command cmd = new Command("DeleteEvent", true);
            cmd.AddParameter("Id", e.Id);
            cmd.AddParameter("Name", e.Name);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Description", e.Description);
            cmd.AddParameter("CreatorId", e.CreatorId);
            cmd.AddParameter("DepartmentId", e.DepartmentId);
            cmd.AddParameter("AdminId", UserId);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
        
        public static Event Get(int id)
        {
            Command cmd = new Command("GetEvent", true);
            cmd.AddParameter("EventId ", id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEvent()).FirstOrDefault();
        }

        public static IEnumerable<Event> GetAll()
        {
            Command cmd = new Command("GetAllEvents", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEvent());
        }

        public static IEnumerable<Event> GetAllActive()
        {
            Command cmd = new Command("GetAllActiveEvents", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEvent());
        }

        public static IEnumerable<Event> GetAllActiveForUser(int UserId)
        {
            Command cmd = new Command("GetAllActiveEventsForUser", true);
            cmd.AddParameter("EmpId ", UserId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEvent());
        }

        public static bool Participate(int EventId, int EmpId)
        {
            Command cmd = new Command("RegisterEmployeeToEvent", true);
            cmd.AddParameter("EmployeeId", EmpId);
            cmd.AddParameter("EventId", EventId);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static IEnumerable<EmployeeEvent> GetSubscriptionStatus(int EventId)
        {
            Command cmd = new Command("GetSubscriptionStatus", true);
            cmd.AddParameter("EventId", EventId);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployeeEvent());
        }

        public static IEnumerable<EmployeeEvent> GetEmployeeSubscriptionStatus(int EventId,int EmpId)
        {
            Command cmd = new Command("GetEmployeeSubscriptionStatus", true);
            cmd.AddParameter("EmployeeId", EmpId);
            cmd.AddParameter("EventId", EventId);
           return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployeeEvent());
        }
    }
}
