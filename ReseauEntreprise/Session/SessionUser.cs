using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Client.Data;
using Model.Client.Service;

namespace Réseau_d_entreprise.Session
{
    public static class SessionUser
    {

        public static User GetUser()
        {
            return (User)HttpContext.Current.Session["User"];
        }
        public static void SetUser(User user)
        {
            HttpContext.Current.Session["User"] = user;
        }

        public static void Reset()
        {
            HttpContext.Current.Session.RemoveAll();
        }
    }
}