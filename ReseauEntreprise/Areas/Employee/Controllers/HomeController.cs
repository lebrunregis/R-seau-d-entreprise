using Model.Global.Service;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using D = Model.Global.Data;

namespace ReseauEntreprise.Employee.Controllers
{
    [RouteArea("Employee")]
    public class HomeController : Controller
    {
        [EmployeeRequired]
        public ActionResult Index()
        {
            int Employee_Id = SessionUser.GetUser().Id;
            IEnumerable<D.Team> Teams = TeamService.GetAllActiveTeamsForEmployee(Employee_Id);
            List<ProjectTeams> ProjectTeamList = new List<ProjectTeams>();
            foreach(D.Team team in Teams)
            {
                IEnumerable<D.>TeamList
                if (ProjectTeamList.Select(pt => pt.Project.Id).Contains(team.Project_Id))
                {

                }
            }
            IndexModel form = new IndexModel();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}