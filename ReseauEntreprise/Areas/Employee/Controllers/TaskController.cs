using System.Collections.Generic;
using System.Web.Mvc;
using C = Model.Client.Data;
using Réseau_d_entreprise.Session;
using ReseauEntreprise.Areas.Employee.Models.ViewModels.Project;
using Model.Client.Service;

namespace ReseauEntreprise.Areas.Employee.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {

                int Employee_Id = SessionUser.GetUser().Id;
                List<ListForm> list = new List<ListForm>();
                foreach (C.Task Task in TaskService.GetForUser(Employee_Id))
                {
                    ListForm form = new ListForm();
                    list.Add(form);
                }
                return View(list);
         
        }
    }
}