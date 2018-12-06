using Réseau_d_entreprise.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.Client.Data;
using Model.Client.Service;

namespace ReseauEntreprise.Session.Attributes
{
    public class ProjectManagerRequiredAttribute : AuthorizeAttribute
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool accessAllowed = false;
            Task task = null;
            Project project = null;
            string req = httpContext.Request.Url.Segments.Last();

            try
            {
                if (ActionName.Equals("Edit"))
                {
                    int.TryParse(req, out int taskId);
                    task = TaskService.Get(taskId, SessionUser.GetUser().Id);
                    project = ProjectService.GetProjectById(task.ProjectId);
                }
                else if (ActionName.Equals("AddProjectTask") || ActionName.Equals("ProjectTasks"))
                {
                    int.TryParse(req, out int projId);
                    project = ProjectService.GetProjectById(projId);
                }

                if (SessionUser.GetUser().Id == project.ProjectManagerId)
                {
                    accessAllowed = true;
                }
            }
            catch
            {
                return false;
            }

            return accessAllowed;
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                       { "action", "Index" },
                                       { "controller", "Home" }
                                       });
        }
    }
}