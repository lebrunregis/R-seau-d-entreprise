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
            List<ListForm> list = new List<ListForm>();
            foreach (Project projet in ProjectService.GetAll())
            {
                ListForm form = new ListForm(projet);
                list.Add(form);
            }
            return View(list);
        }

    }
}