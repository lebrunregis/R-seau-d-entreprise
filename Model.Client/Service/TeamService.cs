using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System.Collections.Generic;

namespace Model.Client.Service
{
    public static class TeamService
    {

        public static int? Create(Team t, int TeamLeader)
        {
            return GS.TeamService.Create(Mappers.ToGlobal(t), TeamLeader);
        }

        public static bool Edit(int User, Team t, int TeamLeader)
        {
            return GS.TeamService.Edit(User,Mappers.ToGlobal(t), TeamLeader);
        }

        public static bool Delete(Team t, int User)
        {
            return GS.TeamService.Delete(Mappers.ToGlobal(t),User);
        }

        public static Data.Team GetTeamById(int Team_Id)
        {
            return Mappers.ToClient(GS.TeamService.GetTeamById(Team_Id));

        }

        public static IEnumerable<Data.Team> GetAllActive()
        {
            List<Team> Teams = new List<Team>();
            IEnumerable<GD.Team> GlobalTeams = GS.TeamService.GetAllActive();
            foreach (GD.Team Team in GlobalTeams)
            {
                Teams.Add(Mappers.ToClient(Team));
            }
            return Teams;
        }

        public static IEnumerable<Team> GetAllActiveTeamsForEmployee(int id)
        {
            List<Team> Teams = new List<Team>();
            foreach (GD.Team Team in GS.TeamService.GetAllActiveTeamsForEmployee(id))
            {
                Teams.Add(Mappers.ToClient(Team));
            }

            return Teams;
        }

        public static IEnumerable<Data.Team> GetAll()
        {
            List<Team> Teams = new List<Team>();
            IEnumerable<GD.Team> GlobalTeams = GS.TeamService.GetAll();
            foreach (GD.Team Team in GlobalTeams)
            {
                Teams.Add(Mappers.ToClient(Team));
            }
            return Teams;
        }

        public static IEnumerable<Team> GetActiveTeamsForTeamLeader(int id)
        {
            List<Team> Teams = new List<Team>();
            foreach(GD.Team Team in GS.TeamService.GetActiveTeamsForTeamLeader(id))
            {
                Teams.Add(Mappers.ToClient(Team));
            }

            return Teams;
        }

        public static int? GetTeamLeaderId(int Team_Id)
        {
            return GS.TeamService.GetTeamLeaderId(Team_Id);
        }
        public static IEnumerable<Employee> GetAllEmployeesForTeam(int Team_Id)
        {
            List<Employee> ClientEmployees = new List<Employee>();
            IEnumerable<GD.Employee> GlobalEmployees = GS.TeamService.GetAllEmployeesForTeam(Team_Id);
            foreach (GD.Employee employee in GlobalEmployees)
            {
                ClientEmployees.Add(Mappers.ToClient(employee));
            }
            return ClientEmployees;
        }
        public static bool AddEmployee(int Team_Id, int Employee_Id, int User)
        {
            return GS.TeamService.AddEmployee(Team_Id, Employee_Id, User);
        }
        public static bool RemoveEmployee(int Team_Id, int Employee_Id, int User)
        {
            return GS.TeamService.RemoveEmployee(Team_Id, Employee_Id, User);
        }

        public static bool IsInTeam(int Team_Id, int Employee_Id)
        {
            return GS.TeamService.IsInTeam(Team_Id, Employee_Id);
        }

        public static IEnumerable<Data.Team> GetActiveTeamsInCommon(int Emp_Id_1, int Emp_Id_2)
        {
            List<Team> Teams = new List<Team>();
            foreach (GD.Team Team in GS.TeamService.GetActiveTeamsInCommon( Emp_Id_1, Emp_Id_2))
            {
                Teams.Add(Mappers.ToClient(Team));
            }

            return Teams;
        }
    }
}
