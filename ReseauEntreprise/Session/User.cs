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

        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public IEnumerable<Team> AuthorizedTeams { get; set; }
        public IEnumerable<Task> AuthorizedTasks { get; set; }
        public IEnumerable<Project> ProjectManager { get; set; }
        public IEnumerable<Project> AuthorizedProjects { get; set; }
        public IEnumerable<int> HeadOfDepartment { get; set; }
        public IEnumerable<Department> AuthorizedDepartmments { get; set; }

        public User(int id)
        {
            Id = id;
        }

        public void Update()
        {
            IsAdmin = AuthService.IsAdmin(Id);
            AuthorizedTeams = TeamService.GetAllActiveTeamsForEmployee(Id);
           // AuthorizedTasks = TaskService.GetForUser(Id);
            AuthorizedDepartmments = DepartmentService.GetEmployeeActiveDepartments(Id);
        }
    }
}