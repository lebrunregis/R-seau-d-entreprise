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
    public static class ProjectService
    {

        public static int? Create(Project p, int ProjectManager)
        {

            return 
        }

        public static bool Edit(int User,Project p)
        {

            return 
        }

        public static bool Delete(Project p,int User)
        {

            return 
        }

        public static Data.Project GetProjectById(int ProjectId)
        {

            return 
        }

        public static IEnumerable<Data.Project> GetAllActive()
        {

            return 
        }

        public static IEnumerable<Data.Project> GetAll()
        {
            return
        }
        public static int? GetProjectManagerId(int ProjectId)
        {

            return 
        }

        public static IEnumerable<Data.Team> GetAllTeamsForProject(int ProjectId)
        {

            return 
        }
    }
}
