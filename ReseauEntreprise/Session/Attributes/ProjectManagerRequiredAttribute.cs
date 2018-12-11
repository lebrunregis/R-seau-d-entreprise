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
            string Id = httpContext.Request.Url.Segments.Last();

            try
            {
                IEnumerable<Project> projects = SessionUser.GetUser().AuthorizedProjects;
                int UserId = SessionUser.GetUser().Id;
                IEnumerable<Project> results = from project 
                                               in projects
                                               where project.ProjectManagerId == UserId && project.Id == int.Parse(Id)
                                               select project;
                if (results.Count() == 1)
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