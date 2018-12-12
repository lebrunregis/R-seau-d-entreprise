using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Client.Data;
using Model.Client.Service;

namespace Réseau_d_entreprise.Session
{
    public class User
    {

        public int Id { get;  }
        public bool IsAdmin { get => AuthService.IsAdmin(Id);  }
        public IEnumerable<Team> AuthorizedTeams { get => TeamService.GetAllActiveTeamsForEmployee(Id); }
        public IEnumerable<Task> AuthorizedTasks { get => TaskService.GetForUser(Id); }
        public IEnumerable<Project> AuthorizedProjects { get => ProjectService.GetAllActive(); }
        public IEnumerable<int> HeadOfDepartment { get;  }
        public IEnumerable<Department> AuthorizedDepartmments { get => DepartmentService.GetEmployeeActiveDepartments(Id); }

        public User(int id)
        {
            Id = id;
        }
    }
}