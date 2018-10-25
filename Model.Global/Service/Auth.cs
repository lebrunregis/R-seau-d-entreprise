﻿using Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    public static class Auth
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Confirm(String email, string pwd)
        {
            Command cmd = new Command("SP_ConfirmLogin", true);
            cmd.AddParameter("Email", email);
            cmd.AddParameter("Password", pwd);
            return (int?)Connection.ExecuteScalar(cmd);
        }
        public static int Register(Employee e)
        {
            Command cmd = new Command("SP_Register", true);
            cmd.AddParameter("LastName", e.LastName);
            cmd.AddParameter("FirstName", e.FirstName);
            cmd.AddParameter("Email", e.Email);
            cmd.AddParameter("Password", e.Passwd);
            cmd.AddParameter("RegNat", e.RegNat);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Phone", e.Phone);
            return (int)Connection.ExecuteScalar(cmd);
        }
        public static bool IsAdmin(int Employee_Id)
        {
            Command cmd = new Command("SP_ConfirmAdmin", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            if (Connection.ExecuteScalar(cmd) is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
