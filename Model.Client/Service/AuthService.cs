using Model.Client.Data;
using Model.Client.Mapper;
using G =Model.Global.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Service
{
    public static class AuthService
    {

        public static int? Confirm(String email, string pwd)
        {

            return G.AuthService.Confirm(email, pwd);
        }
        public static int Register(Data.Employee e)
        {

            return G.AuthService.Register(Mappers.ToGlobal(e));
        }
        public static bool IsAdmin(int Employee_Id)
        {

            return G.AuthService.IsAdmin(Employee_Id);
        }
    }
}
