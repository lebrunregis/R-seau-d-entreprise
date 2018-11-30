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
                foreach (C.Project Project in TaskService.Get(0))
                {
                    int? ManagerId = ProjectService.GetProjectManagerId((int)Project.Id);
                    C.Employee Manager = EmployeeService.Get((int)ManagerId);
                    ListForm form = new ListForm(Project, Manager, Employee_Id);
                    list.Add(form);
                }
                return View(list);
         
        }
    }
}