using Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Admin.Models.ViewModels.Project;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    [RouteArea("Employee")]
    [AdminRequired]
    public class ProjectController : Controller
    {

        public ActionResult Index()
        {
            List<ListForm> List = new List<ListForm>();
            foreach (Project Project in ProjectService.GetAll())
            {
                ListForm form = new ListForm(Project, EmployeeService.Get((int)ProjectService.GetProjectManagerId((int)Project.Id)), EmployeeService.Get(Project.CreatorId));
                List.Add(form);
            }
            return View(List);
        }
       
    }
}