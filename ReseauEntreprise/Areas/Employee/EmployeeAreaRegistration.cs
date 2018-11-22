﻿using System.Web.Mvc;

namespace ReseauEntreprise.Areas.Employee
{
    public class EmployeeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Employee";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Employee_default",
                "Employee/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "ReseauEntreprise.Areas.Employee.Controllers" }
            );
        }
    }
}