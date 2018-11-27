using Model.Client.Data;
using Model.Client.Mapper;
using G = Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Service
{
    public static class TeamService
    {

        public static int? Create(Team t, int TeamLeader)
        {

            return 
        }

        public static bool Edit(int User, Team t, int TeamLeader)
        {

            return 
        }

        public static bool Delete(Team t, int User)
        {

            return 
        }

        public static Data.Team GetTeamById(int Team_Id)
        {

            return 
        }

        public static IEnumerable<Data.Team> GetAllActive()
        {

            return 
        }

        public static IEnumerable<Data.Team> GetAll()
        {

            return 
        }
        public static int? GetTeamLeaderId(int Team_Id)
        {

            return 
        }
        public static IEnumerable<Employee> GetAllEmployeesForTeam(int Team_Id)
        {

            return 
        }
        public static bool AddEmployee(int Team_Id, int Employee_Id, int User)
        {

            return 
        }
        public static bool RemoveEmployee(int Team_Id, int Employee_Id, int User)
        {

            return 
        }

        public static bool IsInTeam(int Team_Id, int Employee_Id)
        {

            return 
        }
    }
}
