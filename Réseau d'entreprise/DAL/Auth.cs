using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Réseau_d_entreprise.DAL
{
    public static class Auth
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", "Server='FORMAVDI1601\\TFTIC';Database=Database;User Id= 'Auth';Password = '340$Uuxwp7Mcxo7Khy'; ");

        public static int Confirm(String login, string pwd)
        {
            Command cmd = new Command("SP_ConfirmLogin", true);
            cmd.AddParameter("login", login);
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