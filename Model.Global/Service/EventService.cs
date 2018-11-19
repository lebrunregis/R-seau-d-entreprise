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
    class EventService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int Create(Event e ){
            Command cmd = new Command("CreateEvent", true);
            cmd.AddParameter("Name", e.Name);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Description", e.Description);
            cmd.AddParameter("StartDate", e.StartDate);
            cmd.AddParameter("EndDate", e.EndDate);
            cmd.AddParameter("CreatorId", e.CreatorId);
            cmd.AddParameter("DepartmentId", e.DepartmentId);
            cmd.AddParameter("Open", e.Open);
            return (Connection.ExecuteNonQuery(cmd));
        }

        public static bool Edit(Event e)
        {
            Command cmd = new Command("UpdateEvent", true);
            cmd.AddParameter("Id", e.Id);
            cmd.AddParameter("Name", e.Name);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Description", e.Description);
            cmd.AddParameter("StartDate", e.StartDate);
            cmd.AddParameter("EndDate", e.EndDate);
            cmd.AddParameter("CreatorId", e.CreatorId);
            cmd.AddParameter("DepartmentId", e.DepartmentId);
            cmd.AddParameter("Open", e.Open);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool Delete(Event e)
        {
            Command cmd = new Command("DeleteEvent", true);
            cmd.AddParameter("Id", e.Id);
            cmd.AddParameter("Name", e.Name);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Description", e.Description);
            cmd.AddParameter("StartDate", e.StartDate);
            cmd.AddParameter("EndDate", e.EndDate);
            cmd.AddParameter("CreatorId", e.CreatorId);
            cmd.AddParameter("DepartmentId", e.DepartmentId);
            return (Connection.ExecuteNonQuery(cmd) > 0);
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

        public static bool Participate(Event ev, Employee emp)
        {
             Command cmd = new Command("RegisterEmployeeToEvent", true);
            cmd.AddParameter("EmployeeId", ev.Id);
            cmd.AddParameter("EventId", emp.Employee_Id);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool SubscribeTo(Event e, IEnumerable<Employee> emps)
        {
             Command cmd = new Command("RegisterEmployeeToEvent", true);
            cmd.AddParameter("EmployeeId", e.Employee_Id);
            cmd.AddParameter("EventId", e.LastName);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
    }
}
