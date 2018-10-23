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

        public static int Confirm(String email, string pwd)
        {
            Command cmd = new Command("SP_ConfirmLogin", true);
            cmd.AddParameter("Email", email);
            cmd.AddParameter("pwd", pwd);
            return (int)Connection.ExecuteScalar(cmd);
        }
        public static int Register(String login, String email, string pwd)
        {
            Command cmd = new Command("SP_Register", true);
            cmd.AddParameter("login", login);
            cmd.AddParameter("email", email);
            cmd.AddParameter("pwd", pwd);
            return (int)Connection.ExecuteScalar(cmd);
        }
    }
}
