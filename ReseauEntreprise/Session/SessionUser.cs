using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Réseau_d_entreprise.Session
{
    public static class SessionUser
    {
        public static User GetSessionUser()
        {
            return (User)HttpContext.Current.Session["User"];
        }
        public static void SetSessionUser(User user)
        {
            HttpContext.Current.Session["User"] = user;
        }
    }
}