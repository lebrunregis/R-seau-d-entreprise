using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Client.Data;

namespace Réseau_d_entreprise.Session
{
    public class User
    {

        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public List<int> TeamLeader { get; set; }
        public List<int> AuthorizedTeams { get; set; }
        public List<int> AuthorizedTasks { get; set; }
        public List<int> ProjectManager { get; set; }
        public List<int> AuthorizedProjects { get; set; }
        public List<int> HeadOfDepartment { get; set; }
        public List<int> AuthorizedDepartmments { get; set; }

        public User(int id)
        {
            Id = id;
        }
    }
}