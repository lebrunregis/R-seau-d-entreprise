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
    public static class TeamService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Team t, int TeamLeader)
        {
            Command cmd = new Command("CreateTeam", true);
            cmd.AddParameter("name", t.Name);
            cmd.AddParameter("team_leader", TeamLeader);
            cmd.AddParameter("Creator_Id", t.Creator_Id);
            cmd.AddParameter("Project_Id", t.Project_Id);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static bool Edit(int User, Team t, int TeamLeader)
        {
            Command cmd = new Command("EditTeam", true);
            cmd.AddParameter("User", User);
            cmd.AddParameter("Team_Id", t.Id);
            cmd.AddParameter("Name", t.Name);
            cmd.AddParameter("TeamLeader", TeamLeader);
            cmd.AddParameter("CreatorId", t.Creator_Id);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool Delete(Team t, int User)
        {
            Command cmd = new Command("DeleteTeam", true);
            cmd.AddParameter("User", User);
            cmd.AddParameter("Team_Id", t.Id);
            cmd.AddParameter("Team_Name", t.Name);
            cmd.AddParameter("Project_Id", t.Project_Id);
            cmd.AddParameter("Creator_Id", t.Creator_Id);
            cmd.AddParameter("Team_Created", t.Created);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static Data.Team GetTeamById(int Team_Id)
        {
            Command cmd = new Command("GetTeam", true);
            cmd.AddParameter("Id", Team_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam()).FirstOrDefault();
        }

        public static IEnumerable<Data.Team> GetAllActive()
        {
            Command cmd = new Command("GetAllActiveTeams", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam());
        }

        public static IEnumerable<Data.Team> GetAll()
        {
            Command cmd = new Command("GetAllTeams", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam());
        }
        public static int? GetTeamLeaderId(int Team_Id)
        {
            Command cmd = new Command("GetTeamLeaderId", true);
            cmd.AddParameter("Team_Id", Team_Id);
            return (int?)Connection.ExecuteScalar(cmd);
        }
        public static IEnumerable<Employee> GetAllEmployeesForTeam(int Team_Id)
        {
            Command cmd = new Command("GetAllEmployeesForTeam", true);
            cmd.AddParameter("Id", Team_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployee());
        }
        public static bool AddEmployee(int Team_Id, int Employee_Id, int User)
        {
            Command cmd = new Command("AddEmployeeToTeam", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            cmd.AddParameter("Team_Id", Team_Id);
            cmd.AddParameter("User", User);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
        public static bool RemoveEmployee(int Team_Id, int Employee_Id, int User)
        {
            Command cmd = new Command("RemoveEmployeeFromTeam", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            cmd.AddParameter("Team_Id", Team_Id);
            cmd.AddParameter("User", User);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }

        public static bool IsInTeam(int Team_Id, int Employee_Id)
        {
            Command cmd = new Command("IsInTeam", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            cmd.AddParameter("Team_Id", Team_Id);
            return (bool)Connection.ExecuteScalar(cmd);
        }

        public static IEnumerable<Team> GetAllActiveTeamsForEmployee(int Employee_Id)
        {
            Command cmd = new Command("GetAllActiveTeamsForEmployee", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam());
        }

        public static IEnumerable<Team> GetActiveTeamsForTeamLeader(int Employee_Id)
        {
            Command cmd = new Command("GetActiveTeamsForTeamLeader", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam());
        }

        public static IEnumerable<Data.Team> GetActiveTeamsInCommon(int Emp_Id_1, int Emp_Id_2)
        {
            Command cmd = new Command("GetActiveTeamsInCommon", true);
            cmd.AddParameter("Emp_Id_1", Emp_Id_1);
            cmd.AddParameter("Emp_Id_2", Emp_Id_2);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToTeam());
        }
    }
}
