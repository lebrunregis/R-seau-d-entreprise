using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System.Collections.Generic;

namespace Model.Client.Service
{
    public static class ProjectService
    {

        public static int? Create(Project p, int ProjectManager)
        {
            return GS.ProjectService.Create(Mappers.ToGlobal(p), ProjectManager);
        }

        public static bool Edit(int User,Project p)
        {
            return GS.ProjectService.Edit( User,Mappers.ToGlobal(p));
        }

        public static bool Delete(Project p,int User)
        {
            return GS.ProjectService.Delete( Mappers.ToGlobal(p),User);
        }

        public static Data.Project GetProjectById(int ProjectId)
        {
            return Mappers.ToClient(GS.ProjectService.GetProjectById(ProjectId));
        }

        public static IEnumerable<Data.Project> GetAllActive()
        {
            List<Project> Projects = new List<Project>();
            IEnumerable<GD.Project> GlobalProjects = GS.ProjectService.GetAllActive();
            foreach (GD.Project Project in GlobalProjects)
            {
                Projects.Add(Mappers.ToClient(Project));
            }
            return Projects;
        }

        public static IEnumerable<Data.Project> GetAll()
        {
            List<Project> Projects = new List<Project>();
            IEnumerable<GD.Project> GlobalProjects = GS.ProjectService.GetAll();
            foreach (GD.Project Project in GlobalProjects)
            {
                Projects.Add(Mappers.ToClient(Project));
            }
            return Projects;
        }

        public static IEnumerable<Project> GetActiveProjectsForManager(int id)
        {
            List<Project> Projects = new List<Project>();
            IEnumerable<GD.Project> GlobalProjects = GS.ProjectService.GetActiveProjectsForManager( id);
            foreach (GD.Project Project in GlobalProjects)
            {
                Projects.Add(Mappers.ToClient(Project));
            }
            return Projects;
        }

        public static int? GetProjectManagerId(int ProjectId)
        {
            return GS.ProjectService.GetProjectManagerId(ProjectId);
        }

        public static IEnumerable<Data.Team> GetAllTeamsForProject(int ProjectId)
        {
            List<Team> Teams = new List<Team>();
            IEnumerable<GD.Team> GlobalTeams = GS.ProjectService.GetAllTeamsForProject(ProjectId);
            foreach (GD.Team Team in GlobalTeams)
            {
                Teams.Add(Mappers.ToClient(Team));
            }
            return Teams;
        }
    }
}
