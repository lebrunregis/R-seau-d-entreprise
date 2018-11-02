using D = Model.Global.Data;
using Model.Global.Service;
using Réseau_d_entreprise.Session.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Admin.Models.ViewModels.Project;
using Model.Global.Data;

namespace ReseauEntreprise.Employee.Controllers
{
    [RouteArea("Employee")]
    [AdminRequired]
    public class ProjectController : Controller
    {

        public ActionResult Index()
        {
            List<ListForm> List = new List<ListForm>();
            foreach (Project Projet in ProjectService.GetAll())
            {
                ListForm form = new ListForm(Projet, EmployeeService.Get((int)ProjectService.GetProjectManagerId(Projet.Id)), EmployeeService.Get(Projet.CreatorId));
                List.Add(form);
            }
            return View(List);
        }
       
    }
}